using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EyeScript : MonoBehaviour
{
    public ColorEffect colorEffect;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            colorEffect.ColorfulEffect();
        }
    }
}
