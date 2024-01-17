using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPickUp : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.Space))
        {
            LightsManager.Instance.SetGlobalLightIntensity(1);
            PickupsManager.Instance.CollectLight();
            Destroy(gameObject);
        }
    }
}
