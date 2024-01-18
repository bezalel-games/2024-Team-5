using UnityEngine;

public class EyePickup : MonoBehaviour
{
    public ColorEffect colorEffect;
    public float colorChangeDuration = 3f;


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.Space))
        {
            PickupsManager.Instance.CollectEye();
            StartCoroutine(colorEffect.ChangeSaturationOverTime(colorChangeDuration));
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            // Destroy(gameObject);
        }
    }
}
