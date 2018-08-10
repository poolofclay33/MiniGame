using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class HealthCounter : NetworkBehaviour
{
    [SyncVar]
    public GameObject life1, life2, life3;

    public DestroyPlayer death;

    void Start()
    {
        life1.gameObject.SetActive(true);
        life2.gameObject.SetActive(true);
        life3.gameObject.SetActive(true);
    }

    void Update()
    {
        if(!isLocalPlayer)
        {
            return;
        }

        CmdtakeLife();
    }

    [Command]
    void CmdtakeLife()
    {
        Debug.Log("CALLED");

        if (Respawn.instance.counter == 1)
        {
            life3.gameObject.SetActive(false);
        }

        if (Respawn.instance.counter == 2)
        {
            life2.gameObject.SetActive(false);
        }

        if (Respawn.instance.counter == 3)
        {
            life1.gameObject.SetActive(false);

            DestroyPlayer.instance.KillPlayer();
        }
    }
}


