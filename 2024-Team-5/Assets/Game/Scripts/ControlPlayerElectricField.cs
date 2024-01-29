using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayerElectricField : MonoBehaviour
{
    [SerializeField] GameObject lightning;
    public static ControlPlayerElectricField Instance { get; private set; }
    
    private void Awake()
    {
        Instance = Instance == null ? this : Instance;
    }
    
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
    
    public void StopLightning()
    {
        lightning.SetActive(false);
    }
}
