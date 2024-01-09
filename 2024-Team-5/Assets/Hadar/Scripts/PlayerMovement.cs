using Gal.Scripts;
using UnityEngine;

namespace Hadar.Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        public IsGrounded isGrounded;
        public Rigidbody objRb;

        [SerializeField] private float speed = 5.0f;
        [SerializeField] private float defaultSpeed = 30f;
        [SerializeField] private float jumpForce = 10.0f;
        [SerializeField] private float flapForce = 5.0f;
        [SerializeField] private float initialFlyFlapTime = 2f;
        [SerializeField] private bool _canJump;
        [SerializeField] private bool _canFly;
        [SerializeField] private LegObject rightLeg;
        [SerializeField] private LegObject leftLeg;
        private float flyFlapTime = 2f;
        private float horizontalInput;
        private float verticalInput;
        private Vector3 connectionOffset;
        private bool _connectedToOther;
        private int legSwitch;
        
        void Start()
        {
            objRb = GetComponent<Rigidbody>();
            flyFlapTime = initialFlyFlapTime;
        }

        private void Update()
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
        
            if (_canJump)
            {
                Jump();
            }
        
            if (_canFly)
            {
                Fly();
            }
        }

        private void Fly()
        {
            if (Input.GetKeyDown(KeyCode.Space) && flyFlapTime < 0)
            {
                objRb.AddForce(Vector3.up * flapForce, ForceMode.Impulse);
                flyFlapTime = initialFlyFlapTime;
            }
        
            if (flyFlapTime >= 0)
            {
                flyFlapTime -= Time.deltaTime;
            }
        }

        private void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded.Grounded())
            {
                objRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }

        private void FixedUpdate()
        {
            Run();
        }

        private void Run()
        {
            objRb.AddForce(new Vector3(horizontalInput, 0, verticalInput) * speed);
        }


        #region Setters and Getters

        public bool GetCanFly() { return _canFly; }
    
        public void SetCanFly(bool canFly) { this._canFly = canFly; }
    
        public bool GetCanJump() { return _canJump; }
    
        public void SetCanJump(bool canJump) { this._canJump = canJump; }
    
        public bool GetConnected() { return _connectedToOther;}

        public void SetByObject(LegObject obj)
        {
            if (legSwitch == 0)
            {
                rightLeg.spriteRenderer.sprite = obj.spriteRenderer.sprite;
                rightLeg.speed = obj.speed;
                rightLeg.canJump = obj.canJump;
                rightLeg.jumpForce = obj.jumpForce;
                
            }
            else
            {
                leftLeg.spriteRenderer.sprite = obj.spriteRenderer.sprite;
                leftLeg.speed = obj.speed;
                leftLeg.canJump = obj.canJump;
                leftLeg.jumpForce = obj.jumpForce;
                
            }
            legSwitch = 1 - legSwitch;
            _canJump = leftLeg.canJump || rightLeg.canJump; // If one object can jump, the player can jump
            speed = defaultSpeed + leftLeg.speed + rightLeg.speed;
            jumpForce = leftLeg.jumpForce + rightLeg.jumpForce;
        }

        #endregion
    
    
    }
}
