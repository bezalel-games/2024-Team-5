using Gal.Scripts;
using UnityEngine;

namespace Hadar.Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        public IsGrounded isGrounded;
        public Rigidbody objRb;

        public enum BodyParts
        {
            Leg,Hand,Back
        }
        
        [SerializeField] private float speed = 5.0f;
        [SerializeField] private float defaultSpeed = 30f;
        [SerializeField] private float jumpForce = 10.0f;
        [SerializeField] private float flapForce = 5.0f;
        [SerializeField] private float initialFlyFlapTime = 2f;
        [SerializeField] private bool _canJump;
        [SerializeField] private bool _canFly;
        [SerializeField] private LegObject rightLeg;
        [SerializeField] private LegObject leftLeg;
        [SerializeField] private BackObject playerBack;
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

        private float flapDuration = 0.5f; // Adjust this value for the duration of each flap
        private float currentFlapTime = 0.0f;

        private void Fly()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                // Add upward force for flying
                objRb.velocity = new Vector3(objRb.velocity.x, objRb.velocity.y + flapForce, objRb.velocity.z);
            }
        }

        private void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded.Grounded())
            {
                print("Jump space pressed");
                objRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }

        private void FixedUpdate()
        {
            Run();
        }

        private void Run()
        {
            Vector3 desiredVelocity = new Vector3(horizontalInput * speed * Time.fixedDeltaTime, objRb.velocity.y, verticalInput * speed * Time.fixedDeltaTime);
            Vector3 velocityChange = desiredVelocity - objRb.velocity;
            velocityChange.x = Mathf.Clamp(velocityChange.x, -speed, speed);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -speed, speed);
            velocityChange.y = 0;

            objRb.AddForce(velocityChange, ForceMode.VelocityChange);
        }



        #region Setters and Getters

        public bool GetCanFly() { return _canFly; }
    
        public void SetCanFly(bool canFly) { this._canFly = canFly; }
    
        public bool GetCanJump() { return _canJump; }
    
        public void SetCanJump(bool canJump) { this._canJump = canJump; }
    
        public bool GetConnected() { return _connectedToOther;}

        public void SetByObject(BodyPartObject obj,BodyParts part)
        {

            if (part == BodyParts.Leg)
            {
                LegObject leg = (LegObject)obj;
                if (legSwitch == 0)
                {
                    rightLeg.spriteRenderer.sprite = leg.spriteRenderer.sprite;
                    rightLeg.speed = leg.speed;
                    rightLeg.canJump = leg.canJump;
                    rightLeg.jumpForce = leg.jumpForce;
                
                }
                else
                {
                    leftLeg.spriteRenderer.sprite = leg.spriteRenderer.sprite;
                    leftLeg.speed = leg.speed;
                    leftLeg.canJump = leg.canJump;
                    leftLeg.jumpForce = leg.jumpForce;
                
                }
                legSwitch = 1 - legSwitch;
                _canJump = leftLeg.canJump || rightLeg.canJump; // If one object can jump, the player can jump
                speed = defaultSpeed + leftLeg.speed + rightLeg.speed;
                jumpForce = leftLeg.jumpForce + rightLeg.jumpForce;
            }
            else if (part == BodyParts.Back)
            {
                BackObject back = (BackObject)obj;
                _canFly = back.canFly;
                playerBack.spriteRenderer.sprite = back.spriteRenderer.sprite;
            }
            
            
        }

        #endregion
    
    
    }
}
