using UnityEngine;

public class EyeScript : MonoBehaviour
{
    public ColorEffect colorEffect;
    public float colorChangeDuration = 3f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        Pickup();
    }

    public void Pickup()
    {
        colorEffect.StartSaturationChange(colorChangeDuration);
    }
}