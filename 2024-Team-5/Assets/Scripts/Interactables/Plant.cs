using UnityEngine;

public class Plant : Interactable
{
    private static readonly int InteractParam = Animator.StringToHash("Interact");


    public bool dark;
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
    
    public void SelfDestruct()
    {
        Destroy(gameObject);
    }
    
}