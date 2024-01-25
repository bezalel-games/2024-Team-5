using System;
using UnityEngine;

public class EyePickup : PickupObject
{
    public ColorEffect colorEffect;
    public float colorChangeDuration = 3f;
    

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.Space))
        {
            Pickup();
            LocalPickup();
        }
    }

    private void LocalPickup()
    {
        OnFinisedAnimation += ShowColor;
    }


    private void ShowColor()
    {
        colorEffect.StartSaturationChange(colorChangeDuration);
        OnFinisedAnimation -= ShowColor;
    }
}
