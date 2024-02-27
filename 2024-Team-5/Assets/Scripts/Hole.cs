using System;
using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField] private Sprite filledHoleSprite;
    [SerializeField] private SpriteRenderer holeRenderer;
    [SerializeField] private Bubbles bubbles;
    private AudioSource audioSource;

    [SerializeField] private Collider2D[] Colliders;
    private void Start()
    {
        holeRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void FillHole()
    {
        holeRenderer.sprite = filledHoleSprite;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.GetComponent<MovableRock>()) return;
        FillHole();
        audioSource.Play();
        bubbles.Burst();
        Destroy(other.gameObject);
        foreach (var col in Colliders)
        {
            col.enabled = false;
        }
    }
}
