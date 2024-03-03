using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMiceAppearanceScript : MonoBehaviour
{
    public static ControlMiceAppearanceScript Instance { get; private set; }
    private bool isMiceVisible = false;
    [SerializeField] private GameObject mouses;

    private void Awake()
    {
        Instance = this;
    }

    public void ChangeMiceAppearance()
    {
        isMiceVisible = !isMiceVisible;
        mouses.SetActive(isMiceVisible);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.K))
        {
            ChangeMiceAppearance();
        }
    }
}
