using System;
using System.Collections;
using UnityEngine;


public class PickupObject : MonoBehaviour
{
    public float animMovementDuration = 1.0f;
    public Transform connectionPlace;
    public Transform rendererTransform;
    public Action OnFinisedAnimation;
    protected static readonly int Connect = Animator.StringToHash("Connect");

    public virtual void Pickup()
    {
        PickupsManager.Instance.StopMoving();
        GetComponent<Animator>().SetTrigger(Connect);
        CameraControl.Instance.Zoom(20,2);
    }


    /**
 * Set by an animation event
 */
    public virtual void ConnectToPlayer()
    {
        ResetPos();
        rendererTransform.GetComponent<SpriteRenderer>().sortingOrder = 10;
        StartCoroutine(MoveObject(transform, connectionPlace, animMovementDuration));
    }

    /**
     * Move an object along a quadratic Bezier curve between two points and then make the manager collect it, and self
     * destruct
     */
    private IEnumerator MoveObject(Transform pointA, Transform pointB, float duration)
    {
        float elapsedTime = 0f;
        
        while (elapsedTime < duration)
        {
            // Update the elapsed time
            if (Vector3.Distance(pointA.position, pointB.position) <= .7f)
            {
                break;
            }

            // Interpolate the position between point A and point B
            float t = Mathf.Clamp01(elapsedTime / duration);
            Vector3 pos = Vector3.Lerp(pointA.position, pointB.position, t);
            transform.position = pos;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    
        OnFinisedAnimation?.Invoke();
        PickupsManager.Instance.CollectObject(gameObject);
        PickupsManager.Instance.StartMoving();
        CameraControl.Instance.Zoom(30,2);
        ControlPlayerElectricField.Instance.StopLightning();
        Destroy(gameObject);
    }


    private void ResetPos()
    {
        transform.position = rendererTransform.position;
        rendererTransform.position = Vector3.zero;
    }
}

