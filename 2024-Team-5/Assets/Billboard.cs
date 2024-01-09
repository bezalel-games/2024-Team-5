using System;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera _mainCamera;
    private void Start()
    {
        _mainCamera = Camera.main;
    }

    void Update()
    {
        var rotation = _mainCamera.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward,
            rotation * Vector3.up);
    }
}