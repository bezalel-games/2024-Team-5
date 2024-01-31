using System;
using System.Collections;
using Game.Scripts.Managers;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public int speed;
    public float leftMotorSpeed;
    public float rightMotorSpeed;
    
    [SerializeField] private int rotateSpeed = 5;
    [SerializeField] private GameObject renderer;
    [SerializeField] private SpriteRenderer headSpriteRenderer;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject leg;

    public static PlayerMovement instance;
    private bool canMove;
    private Rigidbody2D _rb;
    private Vector2 _movement;
    private static readonly int Moving = Animator.StringToHash("Moving");
    private bool flipped;
    private bool _isOnlyHead = true;
    private static readonly int Jump = Animator.StringToHash("Jump");
    private Vector2 _motorsSpeed;
    private Vector2 _motorsShake;
    private bool _shakin;
    private bool _withLeg = false;

    private void Awake()
    {
        instance = this;
        canMove = true;
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _motorsShake = new Vector2(leftMotorSpeed, rightMotorSpeed);
    }
    
    private void FixedUpdate()
    {
         if (canMove) Move();
    }

    private void Move()
    {
        _rb.velocity = new Vector2(_movement.x * speed, _movement.y * speed);
        if (_movement.x > 0 && !flipped)
        {
            Flip();
        }
        
        else if (_movement.x < 0 && flipped)
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
        if (!_isOnlyHead)
        {
            anim.SetBool(Moving, _movement != Vector2.zero);
            return;
        }
        
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

    public void OnJump(InputValue value)
    {
        if (value.Get<float>() == 0 || _isOnlyHead) return;
        anim.SetTrigger(Jump);
        GetComponent<Collider2D>().isTrigger = true;
        StartCoroutine(resumeCollider());
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
        _withLeg = true;
        _isOnlyHead = false;
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


    public bool GetLegStatus()
    {
        return _withLeg;
    }

    public void PickUpWheels()
    {
        speed *= 2;
        MovableRocksManager.Instance.EnableMoveRocks();
    }
}