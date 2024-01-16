using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ColorEffect : MonoBehaviour
{
     private ColorAdjustments colorAdjustments;
    [SerializeField] private Volume volume;

    private void Start()
    {
        volume.profile.TryGet<UnityEngine.Rendering.Universal.ColorAdjustments>(out colorAdjustments);
    }

    public void ColorfulEffect()
    {
        // volume.GetComponent<ColorAdjustments>().saturation.value = 100; 
        colorAdjustments.saturation.value = 100;
        // colorAdjustments.contrast.value = 100;
        // colorAdjustments.hueShift.value = 100;
    }
}