using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayerElectricField : MonoBehaviour
{
    [SerializeField] GameObject lightning;
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Lightning"))
        {
            lightning.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Lightning"))
        {
            lightning.SetActive(false);
        }
    }
}
