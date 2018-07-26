using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HealthCounter : NetworkBehaviour
{

    public GameObject life1, life2, life3;
    public static int health;
    public Respawn playerRespawned;
    public GameObject player;

    // Use this for initialization
    void Start()
    {

        life1.gameObject.SetActive(true);
        life2.gameObject.SetActive(true);
        life3.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isServer)
        {
            return;
        }

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
        }
    }
}


