using UnityEngine;

public class Plant : Interactable
{
    private static readonly int InteractParam = Animator.StringToHash("Interact");

    [SerializeField] private Sprite floatingSprite;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private Animator _anim;
    private Collider2D _col;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _col = GetComponent<Collider2D>();
    }

    public override void Interact()
    {
        spriteRenderer.sprite = floatingSprite;
        _col.enabled = false;
        _anim.SetTrigger(InteractParam);
    }
    
}