using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public int speed;
    public int jumpForce;
    public float leftMotorSpeed;
    public float rightMotorSpeed;
    
    [SerializeField] private int rotateSpeed = 5;
    [SerializeField] private GameObject renderer;
    [SerializeField] private SpriteRenderer headSpriteRenderer;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject leg;

    private Rigidbody2D _rb;
    private Vector2 _movement;
    private PlayerInput _inputAction;
    private static readonly int Moving = Animator.StringToHash("Moving");
    private bool flipped;
    private bool _isOnlyHead = true;
    private static readonly int Jump = Animator.StringToHash("Jump");
    private Vector2 legColSize;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _inputAction = GetComponent<PlayerInput>();
        legColSize = new Vector2(1.8f,4.5f);
    }
    
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rb.AddForce(new Vector2(_movement.x * speed, _movement.y * speed), ForceMode2D.Force);
        if (_movement.x > 0 && !flipped)
        {
            Flip();
        }
        
        else if (_movement.x < 0 && flipped)
        {
            Flip();
        }
        
        if (!_isOnlyHead) return;
        // var dir = Math.Abs(_rb.velocity.x) > .5f || _movement.x != 0 ? _rb.velocity.x : 0;
        headSpriteRenderer.transform.Rotate(Vector3.forward * (rotateSpeed * Math.Abs(_movement.x)),
            Space.Self);
    }

    private void Flip()
    {
        if (flipped)
        {
            var localScale = renderer.transform.localScale;
            localScale = new Vector3( 1, localScale.y, localScale.z);
            renderer.transform.localScale = localScale;
            flipped = false;
        }
        else
        {
            var localScale = renderer.transform.localScale;
            localScale = new Vector3( -1, localScale.y, localScale.z);
            renderer.transform.localScale = localScale;
            flipped = true;
        }
    }

    private void OnMove(InputValue value)
    {
        _movement = value.Get<Vector2>();
        if (!_isOnlyHead)
        {
            anim.SetBool(Moving, _movement != Vector2.zero);
            return;
        }
        
        Vector2 motorsSpeed;
        if (_movement == Vector2.zero || Math.Sign(_movement.x) == Math.Sign(_rb.velocity.x))
        {
            motorsSpeed = Vector2.zero;
        }
        else
        {
            motorsSpeed = new Vector2(leftMotorSpeed, rightMotorSpeed);
        }
        Gamepad.current?.SetMotorSpeeds(motorsSpeed[0],motorsSpeed[1]);

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
        _isOnlyHead = false;
        _rb.drag += 5;
        speed += 15;
        GetComponent<BoxCollider2D>().size = legColSize;
        GetComponent<BoxCollider2D>().offset -= new Vector2(0, 1.5f);
    }
    
}

#region Previous Code

// using Gal.Scripts;
// using UnityEngine;
//
//     public class PlayerMovement : MonoBehaviour
//     {
//         public IsGrounded isGrounded;
//         public Rigidbody objRb;
//         
//         [SerializeField] private float speed = 5.0f;
//         [SerializeField] private float defaultSpeed = 30f;
//         [SerializeField] private float jumpForce = 10.0f;
//         [SerializeField] private float flapForce = 5.0f;
//         [SerializeField] private float initialFlyFlapTime = 2f;
//         [SerializeField] private bool _canJump;
//         [SerializeField] private bool _canFly;
//         [SerializeField] private LegObject rightLeg;
//         [SerializeField] private LegObject leftLeg;
//         [SerializeField] private BackObject playerBack;
//         
//         private float flyFlapTime = 2f;
//         private float horizontalInput;
//         private float verticalInput;
//         private Vector3 connectionOffset;
//         private bool _connectedToOther;
//         private int legSwitch;
//         
//         void Start()
//         {
//             objRb = GetComponent<Rigidbody>();
//             flyFlapTime = initialFlyFlapTime;
//         }
//
//         private void Update()
//         {
//             horizontalInput = Input.GetAxis("Horizontal");
//             verticalInput = Input.GetAxis("Vertical");
//             if (_canJump)
//             {
//                 Jump();
//             }
//         
//             if (_canFly)
//             {
//                 Fly();
//             }
//         }
//
//         private float flapDuration = 0.5f; // Adjust this value for the duration of each flap
//         private float currentFlapTime = 0.0f;
//
//         private void Fly()
//         {
//             if (Input.GetKeyDown(KeyCode.Space))
//             {
//                 // Add upward force for flying
//                 objRb.velocity = new Vector3(objRb.velocity.x, objRb.velocity.y + flapForce, objRb.velocity.z);
//             }
//         }
//
//         private void Jump()
//         {
//             if (Input.GetKeyDown(KeyCode.Space) && isGrounded.Grounded())
//             {
//                 print("Jump space pressed");
//                 objRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
//             }
//         }
//
//         private void FixedUpdate()
//         {
//             Run();
//         }
//
//         private void Run()
//         {
//             Vector3 desiredVelocity = new Vector3(horizontalInput * speed * Time.fixedDeltaTime, objRb.velocity.y,
//                 verticalInput * speed * Time.fixedDeltaTime);
//             Vector3 velocityChange = desiredVelocity - objRb.velocity;
//             velocityChange.x = Mathf.Clamp(velocityChange.x, -speed, speed);
//             velocityChange.z = Mathf.Clamp(velocityChange.z, -speed, speed);
//             velocityChange.y = 0;
//
//             objRb.AddForce(velocityChange, ForceMode.VelocityChange);
//         }
//
//
//
//         #region Setters and Getters
//
//         public bool GetCanFly() { return _canFly; }
//     
//         public void SetCanFly(bool canFly) { this._canFly = canFly; }
//     
//         public bool GetCanJump() { return _canJump; }
//     
//         public void SetCanJump(bool canJump) { this._canJump = canJump; }
//     
//         public bool GetConnected() { return _connectedToOther;}
//
//         public void SetByObject(BodyPartObject obj)
//         {
//
//             if (obj.bodyType == BodyPartObject.BodyType.Leg)
//             {
//                 var leg = (LegObject)obj;
//                 if (transform.position.x < obj.transform.position.x)
//                 {
//                     rightLeg.spriteRenderer.sprite = leg.spriteRenderer.sprite;
//                     rightLeg.speed = leg.speed;
//                     rightLeg.canJump = leg.canJump;
//                     rightLeg.jumpForce = leg.jumpForce;
//                 
//                 }
//                 else
//                 {
//                     leftLeg.spriteRenderer.sprite = leg.spriteRenderer.sprite;
//                     leftLeg.speed = leg.speed;
//                     leftLeg.canJump = leg.canJump;
//                     leftLeg.jumpForce = leg.jumpForce;
//                 
//                 }
//                 legSwitch = 1 - legSwitch;
//                 _canJump = leftLeg.canJump || rightLeg.canJump; // If one object can jump, the player can jump
//                 speed = defaultSpeed + leftLeg.speed + rightLeg.speed;
//                 jumpForce = leftLeg.jumpForce + rightLeg.jumpForce;
//             }
//             
//             else if (obj.bodyType == BodyPartObject.BodyType.Back)
//             {
//                 Debug.Log("back");
//                 var back = (BackObject)obj;
//                 _canFly = back.canFly;
//                 playerBack.spriteRenderer.sprite = back.spriteRenderer.sprite;
//             }
//             
//             
//         }
//
//         #endregion
//     
//     
//     }
//


#endregion
