using Unity.VisualScripting;
using UnityEngine;

public class BulletStickyScript : MonoBehaviour
{
    private Rigidbody rb;
    private Material stickyMaterial;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        stickyMaterial = GetComponent<Material>();
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
        objectToStickTo.gameObject.GetComponent<Renderer>().material = stickyMaterial;
    }
}