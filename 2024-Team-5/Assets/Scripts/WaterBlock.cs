using System;
using UnityEngine;

public class WaterBlock : MonoBehaviour
{
    public Sprite filledSprite;
    public GameObject otherCollider;
    private SpriteRenderer _spriteRenderer;
    private EdgeCollider2D _edgeCollider2D;
    [SerializeField] AudioSource _audioSource;
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _edgeCollider2D = GetComponent<EdgeCollider2D>();
    }
    
    public void Fill()
    {
        _edgeCollider2D.enabled = false;
        _spriteRenderer.sprite = filledSprite;
        _audioSource.Play();
        otherCollider.SetActive(false);
    }
}
