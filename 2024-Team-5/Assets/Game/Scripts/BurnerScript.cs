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
            playerRigidbody2D.AddForce(Vector2.up * hoverForce, ForceMode2D.Force);
        }
    }
}