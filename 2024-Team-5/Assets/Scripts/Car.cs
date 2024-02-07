using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Car : MonoBehaviour, IBreakable
{
    public GameObject wheel;
    public GameObject spring;
    [SerializeField] private int hitPoints;
    [SerializeField] private GameObject renderer;
    public void Break()
    {
        var position = transform.position;
        var createdWheel = Instantiate(wheel, position, Quaternion.identity);
        createdWheel.GetComponent<Rigidbody>().AddForce(new Vector3(1, 1, 1) * Random.Range(1,4), ForceMode.Impulse);
        
        var createdSpring = Instantiate(spring, position, Quaternion.identity);
        createdSpring.GetComponent<Rigidbody>().AddForce(new Vector3(1, 1, 1) * Random.Range(1,4), ForceMode.Impulse);
        Destroy(gameObject);
    }
    
    public void getHit()
    {
        Debug.Log("Car Hit");
        hitPoints--;
        if (hitPoints <= 0)
        {
            Break();
        }
        else
        {
            StartCoroutine(Shake(renderer, .5f, .5f));
        }
    }

    public static IEnumerator Shake(GameObject obj, float intensity, float duration)
    {
        Vector3 originalPosition = obj.transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            obj.transform.position = originalPosition +
                                     new Vector3(Random.insideUnitCircle[0],Random.insideUnitCircle[1],0) * intensity;
            elapsed += Time.deltaTime;
            yield return null;
        }

        obj.transform.position = originalPosition;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        // if (other.transform.GetComponent<Rigidbody>().velocity.magnitude < 2){return;}
        getHit();
    }
}
    
