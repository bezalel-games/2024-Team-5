using System;
using System.Collections;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public float arcHeight = 1.0f;
    public float arcFreq = 3f;
    public float duration = 1.0f;
    public Transform connectionPlace;
    public Transform rendererTransform;
    public Action OnFinisedAnimation;
    protected static readonly int Connect = Animator.StringToHash("Connect");

    protected void Pickup()
    {
        PickupsManager.Instance.StopMoving();
        GetComponent<Animator>().SetTrigger(Connect);
        CameraControl.Instance.Zoom(6,2);
    }
    

    public virtual void ConnectToPlayer()
    {
        ResetPos();
        StartCoroutine(MoveObject(transform, connectionPlace, duration));
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
            pos.y += arcHeight * Mathf.Sin(arcFreq * Mathf.Clamp01(t) * 2*Mathf.PI);
            pointA.position = pos;
            elapsedTime += Time.deltaTime;
            // Debug.Log(t);
            yield return null;
        }
        OnFinisedAnimation?.Invoke();
        PickupsManager.Instance.CollectObject(gameObject);
        PickupsManager.Instance.StartMoving();
        CameraControl.Instance.Zoom(10,2);


        Destroy(gameObject);
    }


    private void ResetPos()
    {
        transform.position = rendererTransform.position;
        rendererTransform.position = Vector3.zero;
    }
}
