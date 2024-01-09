using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeBodyParts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter with: " + other.gameObject.name);
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("OnCollisionEnter with: " + other.gameObject.name);
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerStay with: " + other.gameObject.name);
        if (Input.GetKeyDown(KeyCode.T) && other.gameObject.CompareTag("Collectible"))
        {
            other.transform.parent = transform;
        }
    }
}
