using System.Collections;
using PathCreation;
using UnityEngine;
using Random = UnityEngine.Random;

public class Star : MonoBehaviour
{
    [SerializeField] private GameObject star;
    [SerializeField] private GameObject both;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Sprite mouseUp;
    [SerializeField] private Sprite mouseDown;
    [SerializeField] private SpriteRenderer mouseRenderer;
    [SerializeField] private float speed = 1;

    private Animator _animator;
    private static readonly int Start1 = Animator.StringToHash("Start");
    public Transform caveEntrance;

    private float prevBothX;
    private float prevBothY;
    private float dstTravelled;
    private bool isMoving;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        caveEntrance = FindObjectOfType<caveEntrance>().transform;
        rb = GetComponent<Rigidbody2D>();
        
        StartCoroutine(StopFalling());
    }

    private void LateUpdate()
    {
        if (both.transform.position.x > prevBothX)
        {
            both.transform.localScale = new Vector3(-1, 1, 1);
        }
        
        else if (both.transform.position.x < prevBothX)
        {
            both.transform.localScale = new Vector3(1, 1, 1);
        }
        
        // if (both.transform.position.y > prevBothY)
        // {
        //     mouseRenderer.sprite = mouseUp;
        // }
        // else if (both.transform.position.y < prevBothY)
        // {
        //     mouseRenderer.sprite = mouseDown;
        // }
    }

    private void Update()
    {
        var position = both.transform.position;
        prevBothX = position.x;
        prevBothY = position.y;

        if (!isMoving) return;
        both.transform.position = Vector3.MoveTowards(both.transform.position, caveEntrance.position, speed * Time.deltaTime);
    }
    
    /**
     * Set by an animation event
     */
    public void StartMoving()
    {
        isMoving = true;
    }
    
    IEnumerator StopFalling()
    {
        yield return new WaitForSeconds(Random.Range(1,3));
        rb.bodyType = RigidbodyType2D.Static;
        _animator.SetTrigger(Start1);
    }
    
}
