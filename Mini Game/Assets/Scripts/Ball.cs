using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Ball : NetworkBehaviour
{

    public Rigidbody rigidBall;
    public Transform hand;
    private Rigidbody _instance;

    [Command]
    public void CmdRelease()
    {
        _instance = Instantiate(rigidBall, hand.position, hand.rotation) as Rigidbody;

        _instance.AddForce(transform.forward * 20000);
    }
}
