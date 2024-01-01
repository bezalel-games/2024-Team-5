using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float jumpForce = 10.0f;
    [SerializeField] private float flapForce = 5.0f;
    [SerializeField] private float maxVelocity = 30f;
    private float flyFlapTime = 2f;
    [SerializeField] private float initialFlyFlapTime = 2f;
    [SerializeField] private IsGrounded isGrounded;
    [SerializeField] private bool canJump;
    [SerializeField] private bool canFly;
    [SerializeField] private bool canRun;

    private float horizontalInput;
    private float verticalInput;
    private Vector3 movedirection;
    private Rigidbody objRb;
    private bool _active;

    void Start()
    {
        objRb = GetComponent<Rigidbody>();
        flyFlapTime = initialFlyFlapTime;
    }

    private void Update()
    {
        if (!_active)
        {
            movedirection = Vector3.zero;
            return;
        }
        
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        movedirection = new Vector3(horizontalInput , 0 ,verticalInput);

        if (canJump)
        {
            Jump();
        }
        
        if (canFly)
        {
            Fly();
        }
    }

    private void Fly()
    {
        if (Input.GetKeyDown(KeyCode.Space) && flyFlapTime < 0)
        {
            objRb.AddForce(Vector3.up * flapForce, ForceMode.Impulse);
            flyFlapTime = initialFlyFlapTime;
        }
        
        if (flyFlapTime >= 0)
        {
            flyFlapTime -= Time.deltaTime;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded.Grounded())
        {
            objRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        speed = canRun ? speed : 2f;
        objRb.AddForce(movedirection * speed);
        objRb.velocity = objRb.velocity.magnitude < maxVelocity ? objRb.velocity : objRb.velocity.normalized * maxVelocity;
    }
    
    public void setMode (bool active)
    {
        _active = active;
    }
}
