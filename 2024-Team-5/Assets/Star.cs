using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private Animator _animator;
    private static readonly int Start1 = Animator.StringToHash("Start");

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (rb.velocity.y < 0)
        {
            rb.bodyType = RigidbodyType2D.Static;
            _animator.SetTrigger(Start1);
        }
    }
    
    
    
    
}
