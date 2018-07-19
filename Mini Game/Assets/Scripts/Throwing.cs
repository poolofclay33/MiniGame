using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwing : MonoBehaviour {

    //public GameObject ball;
    public Ball ballScript;

    public void ThrowBall()
    {
        ballScript.Release();
    }
}
