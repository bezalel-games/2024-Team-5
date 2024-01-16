using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupsManager : MonoBehaviour
{
    public static PickupsManager Instance { get; private set; }
    [SerializeField] private Sprite goodEyeSprite;
    [SerializeField] private SpriteRenderer bodyRenderer;
    
    private void Awake()
    {
        Instance = Instance == null ? this : Instance;
    }

    public void CollectEye()
    {
        bodyRenderer.sprite = goodEyeSprite;
    }
}
