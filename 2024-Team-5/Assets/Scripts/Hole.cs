using System;
using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField] private Sprite filledHoleSprite;
    [SerializeField] private SpriteRenderer holeRenderer;

    private void Start()
    {
        holeRenderer = GetComponent<SpriteRenderer>();
    }
    
    public void FillHole()
    {
        holeRenderer.sprite = filledHoleSprite;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<MovableRock>())
        {
            FillHole();
            Destroy(other.gameObject);
        }
    }
}
