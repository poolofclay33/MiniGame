using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCloud : MonoBehaviour {

    public GameObject cloud;
    public GameObject explosion;

    private void Start()
    {
        Destroy(cloud);
        Destroy(explosion);
    }
}
