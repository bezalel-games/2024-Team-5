using UnityEngine;

public class LiftableScript : MonoBehaviour
{
    private bool canAttach = false;
    private Transform attachTo;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canAttach = true;
            attachTo = other.transform;
        }
    }

    private void Update()
    {
        
        if (canAttach && Input.GetKeyDown(KeyCode.Space))
        {
            if (transform.parent == attachTo)
            {
                DetachFromObject();
                canAttach = false;
                attachTo = null;
            }
            else
            {
                AttachToObject();
            }
        }
    }

    private void AttachToObject()
    {
        if (attachTo != null)
        {
            transform.SetParent(attachTo);
        }
    }

    private void DetachFromObject()
    {
        transform.parent = null;
    }
}