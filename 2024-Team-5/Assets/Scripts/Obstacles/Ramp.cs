using UnityEngine;

public class Ramp : Obstacle
{
    [SerializeField] private Collider2D blockedCollider;
    [SerializeField] private Collider2D[] openColliders;
    
    public override void RemoveObstacle()
    {
        blockedCollider.enabled = false;
        foreach (var openCollider in openColliders)
        {
            openCollider.enabled = true;
        }
    }        
}