using System;
using UnityEngine;

public class LegScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().EnableWalking();
            ObstaclesManager.Instance.DisableObstacles();
            Destroy(gameObject);
        }
    }
}
