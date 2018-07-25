using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour {

    public float fallMulti = 2.5f;
    public float lowJumpMulti = 2f;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMulti - 1) * Time.deltaTime;
        } else if(rb.velocity.y > 0 && !Input.GetButton("Jump")) {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMulti - 1) * Time.deltaTime;
        }
    }  
}
 