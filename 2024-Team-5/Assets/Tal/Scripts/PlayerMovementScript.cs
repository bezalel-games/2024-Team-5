using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of character movement
    public float rotationSpeed = 120f; // Speed of character rotation
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Character movement
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * verticalInput * moveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);

        // Character rotation
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 rotation = Vector3.up * horizontalInput * rotationSpeed * Time.deltaTime;

        if (verticalInput != 0f) // Move forward
        {
            rb.MoveRotation(Quaternion.LookRotation(movement.normalized));
        }
        else if (horizontalInput < 0f) // Rotate left
        {
            rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        }
        else if (horizontalInput > 0f) // Rotate right
        {
            rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        }
    }
}