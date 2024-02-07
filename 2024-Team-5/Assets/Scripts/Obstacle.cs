using TMPro;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Collider2D blockedCollider;
    [SerializeField] private Collider2D[] openColliders;
    
    public void RemoveObstacle()
    {
        blockedCollider.enabled = false;
        foreach (var openCollider in openColliders)
        {
            openCollider.enabled = true;
        }
    }        
}
