using Unity.VisualScripting;
using UnityEngine;

public class BulletStickyScript : MonoBehaviour
{
    private Rigidbody rb;
    private bool isStuck = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void OnCollisionEnter(Collider other)
    {
        // Check if the collided object does not have the "Ground" tag and the bullet hasn't stuck yet
        if (!isStuck && !other.CompareTag("Ground"))
        {
            Debug.Log("Bullet collided with " + other.name);
            StickToObject(other);
        }
    }

    void StickToObject(Collider other)
    {
        // Disable the Rigidbody to make the bullet "stick" to the object
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;

        // Attach the bullet to the collided object using a Fixed Joint
        FixedJoint joint = gameObject.AddComponent<FixedJoint>();
        joint.connectedBody = other.GetComponent<Rigidbody>();

        // Set the flag to indicate the bullet is now stuck
        isStuck = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the bullet collided with an object tagged as "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Unstick the bullet from the ground by resetting the isStuck flag
            isStuck = false;
        }
    }
}