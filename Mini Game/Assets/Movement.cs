using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    Animator _anim;
    public float speed;
    public float jumpForce;
    public float gravity;
    private CharacterController controller;

    private Vector3 moveDirection = Vector3.zero;

    private Rigidbody rb;

    void Start()
    {
        _anim = GameObject.FindWithTag("Player").GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        CharacterController controller = gameObject.GetComponent<CharacterController>();

        if(controller.isGrounded) 
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal") * speed, moveDirection.y, Input.GetAxis("Vertical") * speed);

            if(Input.GetButtonDown("Jump")) 
            {
                moveDirection.y = jumpForce;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;

        controller.Move(moveDirection * Time.deltaTime);

        _anim.SetBool("Grounded", controller.isGrounded);
        _anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));
    }
}
