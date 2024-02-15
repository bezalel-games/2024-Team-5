using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public int speed;
    public float leftMotorSpeed;
    public float rightMotorSpeed;
    
    [SerializeField] private GameObject renderer;
    [SerializeField] private SpriteRenderer headSpriteRenderer;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject leg;
    
    public static PlayerMovement instance;
    private bool canMove;
    private Rigidbody2D _rb;
    private Vector2 _movement;
    private bool flipped;
    private bool _hasWheels;
    private Vector2 _motorsSpeed;
    private Vector2 _motorsShake;
    private bool _shakin;
    private int moveDirForAnimation;
    private PlayerAnimationsManager _playerAnimationsManager;
    
    /**
     * need to be 1.7 in order to be parallel to the isometric ground
     */
    private float Xoffset;
    private void Awake()
    {
        instance = this;
        canMove = true;
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _motorsShake = new Vector2(leftMotorSpeed, rightMotorSpeed);
        _playerAnimationsManager = GetComponent<PlayerAnimationsManager>();
    }
    
    private void Update()
    {
         Move();
    }

    private void Move()
    {
        _playerAnimationsManager.SetPlayerAnimation(_movement);
        if (canMove)
        {
            _rb.velocity = new Vector2(_movement.x, _movement.y).normalized * speed;
        }
        
        if (_movement.x > 0 && !flipped || _movement.y < 0 && _movement.x == 0 && !flipped)
        {
            Flip();
        }
        
        else if (_movement.x < 0 && flipped || _movement.y > 0 && _movement.x == 0 && flipped)
        {
            Flip();
        }
    }

    private void Flip()
    {
        if (flipped)
        {
            var localScale = renderer.transform.localScale;
            localScale = new Vector3( -1, localScale.y, localScale.z);
            renderer.transform.localScale = localScale;
            flipped = false;
        }
        
        else
        {
            var localScale = renderer.transform.localScale;
            localScale = new Vector3( 1, localScale.y, localScale.z);
            renderer.transform.localScale = localScale;
            flipped = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _shakin = true;
        _motorsSpeed = _motorsShake;
        StartCoroutine(StopShake());
    }

    private IEnumerator StopShake()
    {
        yield return new WaitForSeconds(0.5f);
        _shakin = false;
        _motorsSpeed = Vector2.zero;
    }


    private void OnMove(InputValue value)
    {
        _movement = value.Get<Vector2>();
        _movement.x *= Xoffset;
        
        if ((_movement == Vector2.zero || Math.Sign(_movement.x) == Math.Sign(_rb.velocity.x)) && !_shakin)
        {
            _motorsSpeed = Vector2.zero;
        }
        else
        {
            _motorsSpeed = _motorsShake;
        }
        
        Gamepad.current?.SetMotorSpeeds(_motorsSpeed[0],_motorsSpeed[1]);
    }
    
    IEnumerator resumeCollider()
    {
        yield return new WaitForSeconds(3f);
        GetComponent<Collider2D>().isTrigger = false;
    }
    
    [ContextMenu("enable walking")]
    public void EnableWalking()
    {
        headSpriteRenderer.transform.rotation = quaternion.identity;
        leg.SetActive(true);
        _hasWheels = false;
        _rb.drag += 5;
        speed += 15;
    }

    public void DisableMove()
    {
        canMove = false;
        _rb.velocity = Vector2.zero;
    }
    
    public void EnableMove()
    {
        canMove = true;
    }

    public void PickUpWheels()
    {
        speed += 5;
        _hasWheels = true;
    }

    //TODO: delete?
    public void Crawl(int dir) // set by animation event
    {
        
        switch (dir)
        {
            case 0:
            {
                _rb.AddForce(Vector2.right * speed * moveDirForAnimation, ForceMode2D.Impulse);
                break;
            }
            case 1:
                _rb.AddForce(Vector2.down * speed, ForceMode2D.Impulse);
                break;
            case 2:
                _rb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
                break;
        }
    }
    
    public bool HasWheels()
    {
        return _hasWheels;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        var position = transform.position;
        Gizmos.DrawLine(position, _movement * speed + (Vector2)position);
    }
}