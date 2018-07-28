using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour {

    public static DestroyPlayer instance;

    public void Start()
    {
        instance = this;
    }

    public void KillPlayer()
    {
        Destroy(gameObject);
    }
}
