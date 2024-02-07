using System;
using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField] private Sprite filledHoleSprite;
    [SerializeField] private SpriteRenderer holeRenderer;
    [SerializeField] private Bubbles bubbles;

    [SerializeField] private Collider2D[] Colliders;
    private void Start()
    {
        holeRenderer = GetComponent<SpriteRenderer>();
    }

    private void FillHole()
    {
        holeRenderer.sprite = filledHoleSprite;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.GetComponent<MovableRock>()) return;
        FillHole();
        bubbles.Burst();
        Destroy(other.gameObject);
        foreach (var col in Colliders)
        {
            col.enabled = false;
        }
    }
}
