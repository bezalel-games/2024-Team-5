using System;
using UnityEngine;
using UnityEngine.Serialization;

public class MouseTrace : MonoBehaviour
{
    public GameObject trails;
    public SpriteRenderer _renderer;
    private float timeBtwTrails;
    [SerializeField] private float startTimeBtwTrails = 0.05f;

    private void Start()
    {
        timeBtwTrails = startTimeBtwTrails;
    }

    private void Update()
    {
        if (timeBtwTrails <= 0)
        {
            CreateTrails();
            timeBtwTrails = startTimeBtwTrails;
        }
        else
        {
            timeBtwTrails -= Time.deltaTime;
        }
    }
    
    private void CreateTrails()
    {
        var newTrail = Instantiate(trails, transform.position - new Vector3(0,.4f,0), Quaternion.identity);
        // Destroy(newTrail, 1f);
        if (_renderer.flipX)
        {
            newTrail.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
