using System;
using UnityEngine;

public class LegScript : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.Space))
        {
            other.GetComponent<PlayerMovement>().EnableWalking();
            //ObstaclesManager.Instance.DisableObstacles();
            Destroy(gameObject);
        }
    }
}
