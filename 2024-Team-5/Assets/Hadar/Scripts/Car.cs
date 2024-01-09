using System;
using UnityEngine;
using Random = UnityEngine.Random;


public class Car : MonoBehaviour, IBreakable
{
    public GameObject wheel;
    public GameObject spring;
    [SerializeField] private int hitPoints;
    
    public void Break()
    {
        var createdWheel = GameObject.Instantiate(wheel, spring.transform.position, Quaternion.identity);
        createdWheel.GetComponent<Rigidbody>().AddForce(new Vector3(1, 1, 1) * Random.Range(1,4), ForceMode.Impulse);
        
        var createdSpring = GameObject.Instantiate(spring, spring.transform.position, Quaternion.identity);
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
            Shake();
        }
    }

    private void Shake()
    {
        var originalPosition = transform.position;
        var shakeAmount = 4f;
        var shakeDuration = 0.5f;
        var shakeTime = 0f;
        var shakeSpeed = 1.0f;
        while (shakeTime < shakeDuration)
        {
            transform.position = originalPosition + Random.insideUnitSphere * shakeAmount;
            shakeTime += Time.deltaTime * shakeSpeed;
        }
        transform.position = originalPosition;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        // if (other.transform.GetComponent<Rigidbody>().velocity.magnitude < 2){return;}
        getHit();
    }
}
    
