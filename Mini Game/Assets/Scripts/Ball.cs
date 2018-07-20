using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
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

    public void Release()
    {
        _instance = Instantiate(rigidBall, hand.position, hand.rotation) as Rigidbody;

        //transform.parent = null;
        //rigidBall.useGravity = true;
        //rigidBall.isKinematic = false;
        //transform.rotation = parentbone.transform.rotation;

        _instance.AddForce(transform.forward * 20000);
    }
}
