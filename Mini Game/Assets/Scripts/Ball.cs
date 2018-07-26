using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Ball : NetworkBehaviour
{

    public Rigidbody rigidBall;
    public Transform hand;
    private Rigidbody _instance;

    private void Start()
    {
        //transform.parent = parentbone.transform;
        //rigidBall.useGravity = false;
        //rigidBall.isKinematic = true;
    }

    [Command]
    public void CmdRelease()
    {
        _instance = Instantiate(rigidBall, hand.position, hand.rotation) as Rigidbody;

        //transform.parent = null;
        //rigidBall.useGravity = true;
        //rigidBall.isKinematic = false;
        //transform.rotation = parentbone.transform.rotation;

        //NetworkServer.Spawn(rigidBall);

        _instance.AddForce(transform.forward * 20000);
    }
}
