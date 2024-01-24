using UnityEngine;

    public class BurnerPickUp : MonoBehaviour
    {
        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Player") && Input.GetKey(KeyCode.Space))
            {
                PickupsManager.Instance.CollectBurner();
                Destroy(gameObject);
            }
        }
    }