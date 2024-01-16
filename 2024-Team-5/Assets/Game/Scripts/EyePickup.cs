using UnityEngine;

public class EyePickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        LightsManager.Instance.SetGlobalLightIntensity(1);
        PickupsManager.Instance.CollectEye();
        Destroy(gameObject);
    }
}
