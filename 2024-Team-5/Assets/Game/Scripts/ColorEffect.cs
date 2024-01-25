using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ColorEffect : MonoBehaviour
{
    private ColorAdjustments _colorAdjustments;
    [SerializeField] private Volume volume;
    public float startSaturation = -100f;
    public float endSaturation = 0f;
    public float startContrast = 100;
    public float endConstrast = 0f;
    private void Start()
    {
        volume.profile.TryGet(out _colorAdjustments);
        _colorAdjustments.saturation.value = startSaturation;
    }

    private IEnumerator ChangeSaturationOverTime(float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.fixedDeltaTime;
            
            float currentSaturation = Mathf.Lerp(startSaturation, endSaturation, elapsedTime / duration);
            float currentContrast = Mathf.Lerp(startContrast, endConstrast, elapsedTime / duration);

            // Apply the current saturation value 
            _colorAdjustments.saturation.value = (int) currentSaturation;
            _colorAdjustments.contrast.value = (int) currentContrast;
            // Debug.Log("Saturation: " + _colorAdjustments.saturation.value);

            yield return null;
        }
        
        // Ensure that the final saturation is exactly the end value
        _colorAdjustments.saturation.value = endSaturation;
    }
    
    public void StartSaturationChange(float duration)
    {
        StartCoroutine(ChangeSaturationOverTime(duration));
    }
}