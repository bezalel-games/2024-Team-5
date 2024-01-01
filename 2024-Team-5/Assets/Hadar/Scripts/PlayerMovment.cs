using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    private Rigidbody _rb;
    private float _speed = 5f;  
    private float _jumpForce = 5f;
    
    [SerializeField] private isGrounded isGrounded;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");

        if (!Input.GetKeyDown(KeyCode.Space) || !_isGrounded) return;
        _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        _isGrounded = false;
    }
}
