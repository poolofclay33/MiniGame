using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Respawn : NetworkBehaviour
{
<<<<<<< HEAD
    public Transform player;
    public Transform respawnPoint;

    private NetworkStartPosition[] spawnPoints;

    GameObject[] LifeCounter = new GameObject[2];

    private void Start()
    {
        if (isLocalPlayer)
        {
            spawnPoints = FindObjectsOfType<NetworkStartPosition>();
        }
    }


    void OnTriggerEnter(Collider other)
    {
        StartCoroutine("Wait");
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        HealthCounter.health -= 1;
        RpcRespawn();
    }

    [ClientRpc]
    private void RpcRespawn()
    {
        if (isLocalPlayer)
        {
            Vector3 spawnPoint = Vector3.zero;

            if (spawnPoints != null && spawnPoints.Length > 0)
            {
                spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            }

            transform.position = spawnPoint;
        }
    }
}
=======
    public Transform player;
    public static Respawn instance;
    public int counter;
    private int spawnPointIndex;

    private NetworkStartPosition[] spawnPoints;

    GameObject[] LifeCounter = new GameObject[2];

    private void Start()
    {
        instance = this;

        if (isLocalPlayer)
        {
            spawnPoints = FindObjectsOfType<NetworkStartPosition>();
        }

        spawnPointIndex = Random.Range(0, spawnPoints.Length - 1);
    }


    void OnTriggerEnter(Collider other)
    {
        StartCoroutine("Wait");
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        HealthCounter.health -= 1;
        RpcRespawn();
    }

    [ClientRpc]
    private void RpcRespawn()
    {
        if (isLocalPlayer)
        {
            Vector3 spawnPoint = Vector3.zero;

            if (spawnPoints != null && spawnPoints.Length > 0)
            {
                spawnPoint = spawnPoints[spawnPointIndex].transform.position;
                counter++;
            }

            transform.position = spawnPoint;
        }
    }
}
>>>>>>> 95f590fc6450d38e70b454c3018110fbe2aa0997
