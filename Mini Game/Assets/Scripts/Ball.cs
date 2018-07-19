using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

<<<<<<< HEAD
    public Rigidbody rigidBall; 
    public Transform hand;
    private Rigidbody _instance;

    private void Start()
    {
        //transform.parent = parentbone.transform;
        //rigidBall.useGravity = false;
        //rigidBall.isKinematic = true;
=======
    public GameObject parentbone;
    public Rigidbody rigidBall;
    //public GameObject ball;
    public Transform hand;

    private void Start()
    {
        //transform.parent = parentbone.transform;
        //rigidBall.useGravity = false;
        //rigidBall.isKinematic = true;
>>>>>>> 82477bf6cee70d6b8b15fde3b38ec5c8eb7c583e
    }

    public void Release()
    {
<<<<<<< HEAD
        _instance = Instantiate(rigidBall, hand.position, hand.rotation) as Rigidbody;

        //transform.parent = null;
        //rigidBall.useGravity = true;
        //rigidBall.isKinematic = false;
        //transform.rotation = parentbone.transform.rotation;

        _instance.AddForce(transform.forward * 19000);

        StartCoroutine(WaitBoi());
=======
        Rigidbody _instance;

        _instance = Instantiate(rigidBall, hand.position, hand.rotation) as Rigidbody;

        transform.parent = null;
        rigidBall.useGravity = true;
        rigidBall.isKinematic = false;
        transform.rotation = parentbone.transform.rotation;
        _instance.AddForce(transform.forward * 20000);

        //StartCoroutine(MakeBall());
>>>>>>> 82477bf6cee70d6b8b15fde3b38ec5c8eb7c583e
    }

    IEnumerator WaitBoi()
    {
<<<<<<< HEAD
        yield return new WaitForSeconds(5f);
=======
        yield return new WaitForSeconds(3);
>>>>>>> 82477bf6cee70d6b8b15fde3b38ec5c8eb7c583e
    }
}
