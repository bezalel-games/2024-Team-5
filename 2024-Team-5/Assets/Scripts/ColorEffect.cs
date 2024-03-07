using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using URPGlitch.Runtime.AnalogGlitch;
using URPGlitch.Runtime.DigitalGlitch;

public class ColorEffect : MonoBehaviour
{
    private AnalogGlitchVolume analogGlitch;
    private DigitalGlitchVolume digitalGlitch;
    [SerializeField] private Volume volume;
    private void Start()
    {
        volume.profile.TryGet(out analogGlitch);
        volume.profile.TryGet(out digitalGlitch);
    }

    private IEnumerator FixGlitchOverTime(float duration)
    {
        float elapsedTime = 0f;
        var startDigitalGlitch = digitalGlitch.intensity.value;
        var startAnalogGlitch = analogGlitch.colorDrift.value;
        var startScanLine = analogGlitch.scanLineJitter.value;
        var startVerticalJump = analogGlitch.verticalJump.value;
        var startHorizontalShake = analogGlitch.horizontalShake.value;
        
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            // digitalGlitch.intensity.value = Mathf.Lerp(startDigitalGlitch, 1, elapsedTime / duration);
            // analogGlitch.colorDrift.value = Mathf.Lerp(startAnalogGlitch, 1, elapsedTime / duration);
            analogGlitch.scanLineJitter.value = Mathf.Lerp(startScanLine, 1, elapsedTime / duration);
            analogGlitch.verticalJump.value = Mathf.Lerp(startVerticalJump, 1, elapsedTime / duration);
            // analogGlitch.horizontalShake.value = Mathf.Lerp(startHorizontalShake, 1, elapsedTime / duration);
            yield return null;
        }
        
        digitalGlitch.intensity.value = 0;
        analogGlitch.colorDrift.value = 0;
        analogGlitch.scanLineJitter.value = 0;
        analogGlitch.verticalJump.value = 0;
        analogGlitch.horizontalShake.value =0;
    }
    
    public void FixGlitch(float duration)
    {
        StartCoroutine(FixGlitchOverTime(duration));
    }
}