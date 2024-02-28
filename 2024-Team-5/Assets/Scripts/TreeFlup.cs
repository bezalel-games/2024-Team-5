using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFlup : MonoBehaviour
{
    [SerializeField] private Animator animator;


    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Flup");
        }
      
    }
    
}
