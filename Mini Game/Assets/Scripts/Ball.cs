using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

<<<<<<< HEAD
public class Ball : MonoBehaviour
=======
public class Ball : NetworkBehaviour
>>>>>>> b0e40b544f9f5e97dbc9b645275bdf7c814821d2
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
