using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngageElectricField : MonoBehaviour
{
    [SerializeField] private GameObject electricField;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        electricField.SetActive(true);
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        electricField.SetActive(false);
    }
}
