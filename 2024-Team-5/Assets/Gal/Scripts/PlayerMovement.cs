using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Adjust the speed as needed
    [SerializeField] private float jumpForce = 8f; // Adjust the jump force as needed

    private Rigidbody rb;
    // private bool isGrounded;

    public IsGrounded isGrounded;
    public bool canJump;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Check if the player is grounded
        // isGrounded = Physics2D.Raycast(transform.position, Vector3.down, 2.5f);
        
        // Debug.Log("Is Grounded: " + isGrounded.Grounded());

        // Player movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * (speed * Time.deltaTime);
        transform.Translate(movement);

        // Jumping
        if (canJump)
        {
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded.Grounded())
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                Debug.Log("Jumping!");

            }
        }
        
    }

    // private void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawLine(transform.position, transform.position + Vector3.down * 2.5f);
    //     if (isGrounded)
    //     {
    //         Gizmos.color = Color.green;
    //     }
    // }

    
}
