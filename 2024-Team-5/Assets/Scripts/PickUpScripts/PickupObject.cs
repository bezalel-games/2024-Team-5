using System;
using System.Collections;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public float animMovementDuration = 1.0f;
    public Transform connectionPlace;
    public Transform rendererTransform;
    protected Action onFinishedAnimation;
    private static readonly int Connect = Animator.StringToHash("Connect");
    

    protected virtual void Pickup()
    {
        rendererTransform.GetComponent<SpriteRenderer>().sortingOrder = 19;
        PickupsManager.Instance.StopMoving();
        GetComponent<Animator>().SetTrigger(Connect);
        CameraControl.Instance.Zoom(7, 2);
    }


    /**
     * Set by an animation event
     */
    public virtual void ConnectToPlayer()
    {
        ResetPos();
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
        
        onFinishedAnimation?.Invoke();
        PickupsManager.Instance.CollectObject(gameObject);
        PickupsManager.Instance.StartMoving();
        SoundManager.Instance.PlayConnectSound();
        CameraControl.Instance.Zoom(8, 2);
        ControlPlayerElectricField.Instance.StopLightning();
        Destroy(gameObject);
    }


    private void ResetPos()
    {
        transform.position = rendererTransform.position;
        rendererTransform.position = Vector3.zero;
    }
}