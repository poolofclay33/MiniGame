using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

[RequireComponent(typeof(NetworkTransform))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerManager : NetworkBehaviour
{
    //Network syncvar
    [SyncVar(hook = "OnScoreChanged")]
    public int score;
    [SyncVar]
    public Color color;
    [SyncVar]
    public string playerName;
    [SyncVar(hook = "OnLifeChanged")]
    public int lifeCount;

    protected Rigidbody _rigidbody;
    protected CapsuleCollider _collider;
    protected Text _scoreText;
    protected bool _canControl = true;

    //hard to control WHEN Init is called (networking make order between object spawning non deterministic)
    //so we call init from multiple location (depending on what between spaceship & manager is created first).
    protected bool _wasInit = false;

    void Awake()
    {
        //register the spaceship in the gamemanager, that will allow to loop on it.
        PlayerNetworkGameManager.player.Add(this);
    }

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<CapsuleCollider>();

        Renderer[] rends = GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rends)
            //r.material.color = color;

        //We don't want to handle collision on client, so disable collider there

        if (PlayerNetworkGameManager.sInstance != null)
        {//we MAY be awake late (see comment on _wasInit above), so if the instance is already there we init
            Init();
        }
    }

    public void Init()
    {
        if (_wasInit)
            return;

        GameObject scoreGO = new GameObject(playerName + "score");
        scoreGO.transform.SetParent(PlayerNetworkGameManager.sInstance.uiScoreZone.transform, false);
        _scoreText = scoreGO.AddComponent<Text>();
        _scoreText.alignment = TextAnchor.MiddleCenter;
        _scoreText.font = PlayerNetworkGameManager.sInstance.uiScoreFont;
        _scoreText.resizeTextForBestFit = true;
        _scoreText.color = color;
        _wasInit = true;

        UpdateScoreLifeText();
    }

    void OnDestroy()
    {
        PlayerNetworkGameManager.player.Remove(this);
    }


    [ClientCallback]
    void FixedUpdate()
    {
        if (!hasAuthority)
            return;

        if (!_canControl)
        {//if we can't control, mean we're destroyed, so make sure the ship stay in spawn place
            _rigidbody.rotation = Quaternion.identity;
            _rigidbody.position = Vector3.zero;
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
        }
        else
        {
           // CheckExitScreen();
        }
    }

    [ClientCallback]
    void OnCollisionEnter(Collision coll)
    {
        if (isServer)
            return; // hosting client, server path will handle collision

        //if not, we are on a client, so just disable the spaceship (& play destruction aprticle).
        //This way client won't see it's destruction delayed (time for it to happen on server & message to get back)
        NetworkAsteroid asteroid = coll.gameObject.GetComponent<NetworkAsteroid>();

        if (asteroid != null)
        {
            LocalDestroy();
        }
    }

    /*
    void CheckExitScreen()
    {
        if (Camera.main == null)
            return;

        if (Mathf.Abs(_rigidbody.position.x) > Camera.main.orthographicSize * Camera.main.aspect)
        {
            _rigidbody.position = new Vector3(-Mathf.Sign(_rigidbody.position.x) * Camera.main.orthographicSize * Camera.main.aspect, 0, _rigidbody.position.z);
            _rigidbody.position -= _rigidbody.position.normalized * 0.1f; // offset a little bit to avoid looping back & forth between the 2 edges 
        }

        if (Mathf.Abs(_rigidbody.position.z) > Camera.main.orthographicSize)
        {
            _rigidbody.position = new Vector3(_rigidbody.position.x, _rigidbody.position.y, -Mathf.Sign(_rigidbody.position.z) * Camera.main.orthographicSize);
            _rigidbody.position -= _rigidbody.position.normalized * 0.1f; // offset a little bit to avoid looping back & forth between the 2 edges 
        }
    }
    */


    // --- Score & Life management & display
    void OnScoreChanged(int newValue)
    {
        score = newValue;
        UpdateScoreLifeText();
    }

    void OnLifeChanged(int newValue)
    {
        lifeCount = newValue;
        UpdateScoreLifeText();
    }

    void UpdateScoreLifeText()
    {
        if (_scoreText != null)
        {
            _scoreText.text = playerName + "\nSCORE : " + score + "\nLIFE : ";
            for (int i = 1; i <= lifeCount; ++i)
                _scoreText.text += "X";
        }
    }

    //We can't disable the whole object, as it would impair synchronisation/communication
    //So disabling mean disabling collider & renderer only
    public void EnablePlayer(bool enable)
    {
        GetComponent<Renderer>().enabled = enable;
        _collider.enabled = isServer && enable;

        _canControl = enable;
    }

    [Client]
    public void LocalDestroy()
    {
        if (!_canControl)
            return;//already destroyed, happen if destroyed Locally, Rpc will call that later

        EnablePlayer(false);
    }

    //this tell the game this should ONLY be called on server, will ignore call on client & produce a warning
    [Server]
    public void Kill()
    {
        lifeCount -= 1;

        RpcDestroyed();
        EnablePlayer(false);

        if (lifeCount > 0)
        {
            //we start the coroutine on the manager, as disabling a gameobject stop ALL coroutine started by it
            PlayerNetworkGameManager.sInstance.StartCoroutine(PlayerNetworkGameManager.sInstance.WaitForRespawn(this));
        }
    }

    [Server]
    public void Respawn()
    {
        EnablePlayer(true);
        RpcRespawn();
    }

    //
    [Command]
    public void CmdCollideAsteroid()
    {
        Kill();
    }

    //called on client when the player die, spawn the particle (this is only cosmetic, no need to do it on server)
    [ClientRpc]
    void RpcDestroyed()
    {
        LocalDestroy();
    }

    [ClientRpc]
    void RpcRespawn()
    {
        EnablePlayer(true);
    }
}
