using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntennaHole : MonoBehaviour
{
    [SerializeField] private Sprite filledHoleSprite;
    [SerializeField] private SpriteRenderer holeRenderer;
    private AudioSource audioSource;
    private Animator animator;
    [SerializeField] private Collider2D[] Colliders;
    public GameObject mouse;
    private void Start()
    {
        holeRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    private void FillHole()
    {
        holeRenderer.sprite = filledHoleSprite;
        animator.SetTrigger("Fill");
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.GetComponent<MovableRock>()) return;
        FillHole();
        audioSource.Play();
        Destroy(other.gameObject);
        foreach (var col in Colliders)
        {
            col.enabled = false;
        }
    }
    
    /**
     * set by animation
     */
    public void TurnOffMouseRenderer()
    {
        mouse.SetActive( false);
    }
}
