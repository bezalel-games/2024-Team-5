using UnityEngine;

public class LightPickUp :PickupObject
{
    [SerializeField] private int intensity = 1;
    bool playerInTrigger;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        playerInTrigger = true;
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        playerInTrigger = false;
    }
    
    private void Update()
    {
        if (!playerInTrigger || !Input.GetKey(KeyCode.Space)) return;
        Pickup();
        LocalPickup();
    }

    private void LocalPickup()
    {
        OnFinisedAnimation += ChangeLight;
    }

    private void ChangeLight()
    {
        LightsManager.Instance.SetGlobalLightIntensity(intensity);
    }
}
