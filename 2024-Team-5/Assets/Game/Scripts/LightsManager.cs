using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightsManager : MonoBehaviour
{
    public Light2D globalLight;
    public static LightsManager Instance { get; private set; }

    private void Start()
    {
        Instance = this;
    }
    
    public void SetGlobalLightIntensity(float intensity)
    {
        StartCoroutine(EnhanceLight());
    }

    IEnumerator EnhanceLight()
    {
        float time = 0;
        while (time < 4)
        {
            time += Time.deltaTime;
            globalLight.intensity = Mathf.Lerp(0, .5f, time/4);
            yield return null;
        }
       
    }
}
