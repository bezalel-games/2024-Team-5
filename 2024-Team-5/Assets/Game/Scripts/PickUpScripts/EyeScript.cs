using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EyeScript : MonoBehaviour
{
    public ColorEffect colorEffect;
    public float colorChangeDuration = 3f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        // colorEffect.ColorfulEffect();
        StartCoroutine(colorEffect.ChangeSaturationOverTime(colorChangeDuration));
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
}