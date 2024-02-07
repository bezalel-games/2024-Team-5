using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayerElectricField : MonoBehaviour
{
    [SerializeField] GameObject lightning;
    public static ControlPlayerElectricField Instance { get; private set; }
    public Animator animator;
    private void Awake()
    {
        Instance = Instance == null ? this : Instance;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Lightning"))
        {
            // lightning.SetActive(true);
            animator.SetTrigger("StartAntenna");
            
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Lightning"))
        {
            // lightning.SetActive(false);
            animator.SetTrigger("StopAntenna");
        }
    }
    
    public void StopLightning()
    {
        // lightning.SetActive(false);
        animator.SetTrigger("StopAntenna");

    }
    
    public void StartLightning()
    {
        animator.SetTrigger("StartAntenna");

    }
}
