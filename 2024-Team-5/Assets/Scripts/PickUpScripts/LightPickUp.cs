using System;
using UnityEngine;

public class LightPickUp :PickupObject
{
    [SerializeField] private int intensity = 1;
    bool playerInTrigger;

    private void Start()
    {
        Pickup();
    }


    
}
