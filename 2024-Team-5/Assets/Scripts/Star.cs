using System.Collections;
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

    private void Update()
    {
        if (both.transform.position.x > prevBothX)
        {
            both.transform.localScale = new Vector3(-1, 1, 1);
        }
        
        else if (both.transform.position.x < prevBothX)
        {
            both.transform.localScale = new Vector3(1, 1, 1);
        }
        
        if (!isMoving) return;
        both.transform.position = Vector3.MoveTowards(both.transform.position, caveEntrance.position, speed * Time.deltaTime);

        
        var position = both.transform.position;
        prevBothX = position.x;
        prevBothY = position.y;
        
        
    }
    
    /**
     * Set by an animation event
     */
    public void StartMoving()
    {
        isMoving = true;
    }

    private IEnumerator SetAlpha()
    {
        float elapsedTime = 0;
        while (elapsedTime < 1)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / 1);
            mouseRenderer.color = new Color(1, 1, 1, alpha);
            yield return null;
        }
    }
    
    IEnumerator StopFalling()
    {
        yield return new WaitForSeconds(Random.Range(1,3));
        rb.bodyType = RigidbodyType2D.Static;
        _animator.SetTrigger(Start1);
        StartCoroutine(SetAlpha());
    }
    
}
