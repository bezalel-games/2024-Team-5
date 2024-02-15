using System;
using UnityEngine;

public class PressSpace : MonoBehaviour
{
    
    public CanvasGroup canvasGroup;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name != "Player") return;
        canvasGroup.alpha = 1;
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name != "Player") return;
        canvasGroup.alpha = 0;
    }
}
