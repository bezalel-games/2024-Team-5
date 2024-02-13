using UnityEngine;

public class LiftableScript : MonoBehaviour
{
    private bool canAttach = false;
    private Transform attachTo;
    
    private void Start()
    {
        attachTo = PickupsManager.Instance.holdPos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canAttach = true;
        }
    }

    private void Update()
    {
        if (!canAttach || !Input.GetKeyDown(KeyCode.Space)) return;
        
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

    private void AttachToObject()
    {
        if (!attachTo) return;
        transform.SetParent(attachTo);
        transform.localPosition = Vector3.zero;
    }

    private void DetachFromObject()
    {
        transform.parent = null;
        PickupsManager.Instance.DropObject();
    }
}