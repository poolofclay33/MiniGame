using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Throwing : NetworkBehaviour {

    //public GameObject ball;
    public Ball ballScript;

    public void ThrowBall()
    {
        ballScript.CmdRelease();
    }
}
