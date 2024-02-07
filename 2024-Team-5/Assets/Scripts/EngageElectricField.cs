using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngageElectricField : MonoBehaviour
{
    [SerializeField] private GameObject electricField;
    public Animator animator;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        // electricField.SetActive(true);
        animator.SetTrigger("StartAntenna");
        other.gameObject.GetComponent<ControlPlayerElectricField>().StartLightning();
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        // electricField.SetActive(false);
        animator.SetTrigger("StopAntenna");
        other.gameObject.GetComponent<ControlPlayerElectricField>().StopLightning();

    }
}
