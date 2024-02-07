using UnityEngine;

public class WheelsPickUp : PickupObject
{
    private bool _playerInTrigger;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        _playerInTrigger = true;
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        _playerInTrigger = false;
    }
    
    private void Update()
    {
        if (!_playerInTrigger || !Input.GetKey(KeyCode.Space)) return;
        Pickup();
    }

    protected override void Pickup()
    {
        base.Pickup();
        
    }
}
