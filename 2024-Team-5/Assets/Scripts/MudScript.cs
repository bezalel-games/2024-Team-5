using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("collision");
        if (other.transform.CompareTag("Player"))
        {
            Debug.Log("player");
            if (PlayerMovement.instance.HasWheels())
            {
                Debug.Log("leg");
                transform.GetComponent<CapsuleCollider2D>().enabled = false;
            }
        }
    }
}
