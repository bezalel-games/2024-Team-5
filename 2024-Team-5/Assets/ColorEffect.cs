using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ColorEffect : MonoBehaviour
{
    private ColorAdjustments _colorAdjustments;
    [SerializeField] private Volume volume;
    public float startSaturation = -100f;
    public float endSaturation = 0f;

    private void Start()
    {
        volume.profile.TryGet<UnityEngine.Rendering.Universal.ColorAdjustments>(out _colorAdjustments);
        _colorAdjustments.saturation.value = startSaturation;
    }

    // public void ColorfulEffect()
    // {
    //     colorAdjustments.saturation.value = 0;
    //     // colorAdjustments.contrast.value = 100;
    //     // colorAdjustments.hueShift.value = 100;
    // }
    
    public IEnumerator ChangeSaturationOverTime(float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.fixedDeltaTime;
            
            float currentSaturation = Mathf.Lerp(startSaturation, endSaturation, elapsedTime / duration);

            // Apply the current saturation value 
            _colorAdjustments.saturation.value = (int) currentSaturation;
            Debug.Log("Saturation: " + _colorAdjustments.saturation.value);

            yield return null;
        }
        
        // Ensure that the final saturation is exactly the end value
        _colorAdjustments.saturation.value = endSaturation;
    }
}