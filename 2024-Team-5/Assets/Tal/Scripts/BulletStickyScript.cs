using Unity.VisualScripting;
using UnityEngine;

public class BulletStickyScript : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("StickyObject"))
        {
            StickToObject(collision.gameObject);
        }
    }

    void StickToObject(GameObject objectToStickTo)
    {
        FixedJoint joint = objectToStickTo.AddComponent<FixedJoint>();
        joint.connectedBody = rb;
        joint.enableCollision = false;
    }
}