using System;
using UnityEngine;

public class MovableWaterRock : MovableRock
{
    private void OnTriggerStay2D(Collider2D other)  
    {
        var block = other.GetComponent<WaterBlock>();
        if (!block) return;
        if (Vector3.Distance(transform.position, other.transform.position) > 3f) return;
        block.Fill();
        Destroy(gameObject);
    }
}
