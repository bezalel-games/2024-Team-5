using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public IsGrounded isGrounded;
    public Rigidbody objRb;

    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float jumpForce = 10.0f;
    [SerializeField] private float flapForce = 5.0f;
    [SerializeField] private float maxVelocity = 30f;
    [SerializeField] private float initialFlyFlapTime = 2f;
    [SerializeField] private bool _canJump;
    [SerializeField] private bool _canFly;
    
    private float flyFlapTime = 2f;
    private float horizontalInput;
    private float verticalInput;
    private Vector3 movedirection;
    private Vector3 connectionOffset;
    private bool _connectedToOther;
    
    void Start()
    {
        objRb = GetComponent<Rigidbody>();
        flyFlapTime = initialFlyFlapTime;
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        movedirection = new Vector3(horizontalInput , 0 ,verticalInput);

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
        objRb.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void Run()
    {
        objRb.AddForce(movedirection * speed);
        objRb.velocity = objRb.velocity.magnitude < maxVelocity ? objRb.velocity : objRb.velocity.normalized * maxVelocity;
        if (movedirection != Vector3.zero) return;
        var newVel = new Vector3(0, objRb.velocity.y, 0);
        objRb.velocity = newVel;
    }


    #region Setters and Getters

    public bool GetCanFly() { return _canFly; }
    
    public void SetCanFly(bool canFly) { this._canFly = canFly; }
    
    public bool GetCanJump() { return _canJump; }
    
    public void SetCanJump(bool canJump) { this._canJump = canJump; }
    
    public bool GetConnected() { return _connectedToOther;}

    // public void setByObject(LegOject obj)
    // {
    //     this._canJump = obj.canJump;
    //     this.speed = obj.speed;
    //     this.jumpForce = obj.jumpForce;
    // }

    #endregion
    
    
}
