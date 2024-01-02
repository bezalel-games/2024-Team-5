using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovment : MonoBehaviour
{
    public IsGrounded isGrounded;

    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float jumpForce = 10.0f;
    [SerializeField] private float flapForce = 5.0f;
    [SerializeField] private float maxVelocity = 30f;
    private float flyFlapTime = 2f;
    [SerializeField] private float initialFlyFlapTime = 2f;
    [SerializeField] private bool _canJump;
    [SerializeField] private bool _canFly;
    [SerializeField] private bool _canRun;
 
    private float horizontalInput;
    private float verticalInput;
    private Vector3 movedirection;
    public Rigidbody objRb;
    [SerializeField] private bool _active;

    private Vector3 connectionOffset;
    private bool _connectedToOther;
    private GameObject connectedObj;
    void Start()
    {
        objRb = GetComponent<Rigidbody>();
        flyFlapTime = initialFlyFlapTime;
    }

    private void Update()
    {
        if (_connectedToOther)
        {
            transform.position = connectedObj.transform.position + connectionOffset;

        }
        if (!_active )
        {
            movedirection = Vector3.zero;
            return;
        }
        
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
        speed = _canRun ? 20f : 2f;
        maxVelocity = _canRun ? 10f : 5f;
        objRb.AddForce(movedirection * speed);
        objRb.velocity = objRb.velocity.magnitude < maxVelocity ? objRb.velocity : objRb.velocity.normalized * maxVelocity;
        if (movedirection != Vector3.zero) return;
        var newVel = new Vector3(0, objRb.velocity.y, 0);
        objRb.velocity = newVel;
        objRb.rotation = Quaternion.Euler(0, 0, 0);
    }
    
    public void setActive (bool active)
    {
        _active = active;
    }
    
    public void SetConnection (bool connected, Transform parent)
    {
        _connectedToOther = connected;
        transform.parent = parent;
        connectedObj = parent.gameObject;
        connectionOffset = transform.position - connectedObj.transform.position;
    }

    #region Setters and Getters

    public bool GetCanFly() { return _canFly; }
    
    public void SetCanFly(bool canFly) { this._canFly = canFly; }
    
    public bool GetCanJump() { return _canJump; }
    
    public void SetCanJump(bool canJump) { this._canJump = canJump; }
    
    public bool GetCanRun() { return _canRun; }
    
    public void SetCanRun(bool canRun) { this._canRun = canRun;}
    
    public bool GetConnected() { return _connectedToOther;}

    #endregion
    
    
}
