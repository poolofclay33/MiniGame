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

    public float speedHalved = 7.5f;
    public float speedOrigin = 5f;

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

        if(Input.GetKey(KeyCode.F))
        {
            _anim.Play("THROW");
        }
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal"); // set a float to control horizontal input
        float vertical = Input.GetAxis("Vertical"); // set a float to control vertical input
        PlayerMove(horizontal, vertical); // Call the move player function sending horizontal and vertical movements
    }

    private void PlayerMove(float h, float v)
    {
        if (h != 0f || v != 0f) // If horizontal or vertical are pressed then continue
        {
            if (h != 0f && v != 0f) // If horizontal AND vertical are pressed then continue
            {
                speed = speedHalved; // Modify the speed to adjust for moving on an angle
            }
            else // If only horizontal OR vertical are pressed individually then continue
            {
                speed = speedOrigin; // Keep speed to it's original value
            }

            Vector3 targetDirection = new Vector3(h, 0f, v); // Set a direction using Vector3 based on horizontal and vertical input
            rb.MovePosition(rb.position + targetDirection * speed * Time.deltaTime); // Move the players position based on current location while adding the new targetDirection times speed
            RotatePlayer(targetDirection); // Call the rotate player function sending the targetDirection variable
                                           //anim._animRun = true; // Enable the run animation
        }
        else    // If horizontal or vertical are not pressed then continue
        {
            //anim._animRun = false; // Disable the run animation
        }
    }

    private void RotatePlayer(Vector3 dir)
    {
        rb.MoveRotation(Quaternion.LookRotation(dir)); // Rotate the player to look at the new targetDirection
    }
}
