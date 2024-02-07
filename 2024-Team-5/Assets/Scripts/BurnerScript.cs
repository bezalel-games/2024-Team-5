using UnityEngine;

public class HoverScript : MonoBehaviour
{
    [SerializeField] float hoverForce = 5f; // Adjust this value to control the hover force
    [SerializeField] Sprite burnerWithFireSprite; // Drag and drop the sprite for the burner in the inspector
    [SerializeField] Sprite burnerWithOutFireSprite;

    private bool isHovering = false;
    [SerializeField] Rigidbody2D playerRigidbody2D;
    [SerializeField] GameObject player;
    [SerializeField] float maxHoverSpeed = 5f;
    private SpriteRenderer spriteRenderer;

    [SerializeField] float hoverDepth = 5f; // Depth to which the player hovers
    [SerializeField] float hoverSpeed = 2f; // Speed at which the player returns to Z-axis = 0

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !isHovering)
        {
            StartHover();
        }

        if (Input.GetKeyUp(KeyCode.Space) && isHovering)
        {
            StopHover();
        }
    }

    void FixedUpdate()
    {
        if (isHovering)
        {
            PerformHover();
        }
        else
        {
            // Gently move back to Z-axis = 0
            float step = hoverSpeed * Time.fixedDeltaTime;
            transform.position = Vector3.MoveTowards(transform.position,
                new Vector3(transform.position.x, transform.position.y, 0f), step);
        }
    }

    void StartHover()
    {
        isHovering = true;
        spriteRenderer.sprite = burnerWithFireSprite;
    }

    void StopHover()
    {
        isHovering = false;
        spriteRenderer.sprite = burnerWithOutFireSprite;
    }

    void PerformHover()
    {
        if (playerRigidbody2D.velocity.magnitude < maxHoverSpeed)
        {
            // Apply hover force in the forward direction (Z-axis)
            playerRigidbody2D.AddForce(Vector3.forward * hoverForce, ForceMode2D.Force);
        }
    }
}