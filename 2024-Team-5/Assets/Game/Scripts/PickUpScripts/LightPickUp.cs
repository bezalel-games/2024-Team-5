using UnityEngine;

public class LightPickUp :PickupObject
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.Space))
        {
            Pickup();
        }
    }

    public void Pickup()
    {
        LightsManager.Instance.SetGlobalLightIntensity(1);
        PickupsManager.Instance.CollectLight();
        Destroy(gameObject);
    }

    public void ConnectToPlayer(Transform connectionPlace)
    {
        
    }
}
