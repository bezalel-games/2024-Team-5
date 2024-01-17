using UnityEngine;

public class EyePickup : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.Space))
        {
            PickupsManager.Instance.CollectEye();
            Destroy(gameObject);
        }
    }
}
