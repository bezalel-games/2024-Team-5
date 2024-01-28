using System;
using UnityEngine;

public class EyePickup : PickupObject
{
    public ColorEffect colorEffect;
    public float colorChangeDuration = 3f;
    
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
    }

    public override void Pickup()
    {
        base.Pickup();
        OnFinisedAnimation += ShowColor;
    }


    private void ShowColor()
    {
        colorEffect.StartSaturationChange(colorChangeDuration);
        OnFinisedAnimation -= ShowColor;
    }
}
