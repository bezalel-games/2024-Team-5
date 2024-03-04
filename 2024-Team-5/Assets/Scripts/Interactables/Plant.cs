using System.Collections;
using UnityEngine;

public class Plant : Interactable
{
    private static readonly int InteractParam = Animator.StringToHash("Interact");
    private static readonly int Dark = Animator.StringToHash("Dark");


    public bool dark;
    public GameObject shadow;
    [SerializeField] private Sprite floatingSprite;
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    private Animator _anim;
    private Collider2D _col;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _col = GetComponent<Collider2D>();
        _anim.SetBool(Dark, dark);
        _anim.speed = 0;
        StartCoroutine(StartAnimation());
    }

    public override void Interact()
    {
        spriteRenderer.sprite = floatingSprite;
        _col.enabled = false;
        _anim.SetTrigger(InteractParam);
        // Destroy(shadow);
    }
    
    public void SelfDestruct()
    {
        // Destroy(gameObject);
    }

    IEnumerator StartAnimation()
    {
        float time = Random.Range(0.5f, 1.5f);
        yield return new WaitForSeconds(time);
        _anim.speed = 1;
    }
    
}