using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveEnterColider : MonoBehaviour

{
    [SerializeField] private GameObject caveEnterColliderObject;
    public static CaveEnterColider insatnce;

    private void Awake()
    {
        insatnce = this;
    }

    public void destroyCaveEnterCollider()
    {
        Destroy(caveEnterColliderObject);
    }
}