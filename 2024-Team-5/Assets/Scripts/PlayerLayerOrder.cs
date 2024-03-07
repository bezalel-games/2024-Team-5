
using UnityEngine;

public class PlayerLayerOrder : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            // change order in layer
            var playerLayer = gameObject.GetComponent<SpriteRenderer>().sortingOrder;
            var groundLayer = other.gameObject.GetComponent<SpriteRenderer>().sortingOrder;
            playerLayer = groundLayer;
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = playerLayer;
            Debug.Log("Player layer: " + gameObject.GetComponent<SpriteRenderer>().sortingOrder);
            Debug.Log("Ground layer: " + groundLayer);
        }
    }
}
