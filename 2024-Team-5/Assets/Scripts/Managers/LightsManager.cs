using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightsManager : MonoBehaviour
{
    public Light2D globalLight;
    public Light2D playerLight;
    [SerializeField] private float globalLightIntensity = 0.1f;
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
        var startRadius = playerLight.pointLightOuterRadius;
        playerLight.intensity = .4f;
        while (time < 4)
        {
            time += Time.deltaTime;
            globalLight.intensity = Mathf.Lerp(0, globalLightIntensity, time/4);
            playerLight.pointLightOuterRadius = Mathf.Lerp(startRadius, 22, time/4);
            yield return null;
        }
       
    }
}
