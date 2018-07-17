using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public GameObject parentbone;
    public Rigidbody rigidBall;
    public GameObject ball;
    public Transform hand;
    private Rigidbody _instance;

    private void Start()
    {
        transform.parent = parentbone.transform;
        rigidBall.useGravity = false;
        rigidBall.isKinematic = true;
    }

    public void Release()
    {
        transform.parent = null;
        rigidBall.useGravity = true;
        rigidBall.isKinematic = false;
        transform.rotation = parentbone.transform.rotation;
        rigidBall.AddForce(transform.forward * 20000);

        StartCoroutine(MakeBall());
    }

    IEnumerator MakeBall()
    {
        yield return new WaitForSeconds(3);

        _instance = Instantiate(rigidBall, hand.position, hand.rotation);
    }
}
