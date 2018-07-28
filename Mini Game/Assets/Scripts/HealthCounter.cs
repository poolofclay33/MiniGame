<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCounter : MonoBehaviour {

    public GameObject life1, life2, life3;
    public static int health;
    public Respawn playerRespawned;
    public GameObject player;

	// Use this for initialization
	void Start () {
        
        life1.gameObject.SetActive(true);
        life2.gameObject.SetActive(true);
        life3.gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {

        if(Respawn.instance.counter == 1)
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

=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class HealthCounter : NetworkBehaviour
{
    [SyncVar]
    public GameObject life1, life2, life3;
    public Respawn playerRespawned;
    public GameObject player;

    public DestroyPlayer death;

    void Start()
    {
        life1.gameObject.SetActive(true);
        life2.gameObject.SetActive(true);
        life3.gameObject.SetActive(true);
    }

    void Update() //references the respawn script to take away a life from the player once they respawn.
    {

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

            DestroyPlayer.instance.KillPlayer(); //destroy player once their third life is up. 
        }
    }
}


>>>>>>> b0e40b544f9f5e97dbc9b645275bdf7c814821d2
