using UnityEngine;

public class CameraPickup : PickupObject
{
    public ColorEffect colorEffect;
    public float colorChangeDuration = 3f;

    bool playerInTrigger;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        playerInTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        playerInTrigger = false;
    }

    private void Update()
    {
        if (!playerInTrigger || !Input.GetKey(KeyCode.Space)) return;
        Pickup();
    }

    protected override void Pickup()
    {
        base.Pickup();
        onFinishedAnimation += ShowColor;
        onFinishedAnimation += SoundManager.Instance.EnableSound;
    }


    private void ShowColor()
    {
        colorEffect.FixGlitch(colorChangeDuration);
        onFinishedAnimation -= ShowColor;
    }
}

