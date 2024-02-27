using System;
using UnityEngine;

public class MovableRock : Obstacle
{
    protected Rigidbody2D rb;
    private AudioSource audioSource;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (rb.velocity.magnitude > 0.1f)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
    }

    public override void RemoveObstacle()
    {
        EnableRock();
    }
    
    public void EnableRock()
    {
        if(!rb) rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
    
    
}