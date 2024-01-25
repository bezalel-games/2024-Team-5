using System.Collections;
using UnityEngine;
using Cinemachine;

public class CameraControl : MonoBehaviour
{
    public static CameraControl Instance { get; private set; }
    public CinemachineVirtualCamera vcam;
    
    private void Awake()
    {
        Instance = Instance == null ? this : Instance;
    }
    
    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
    }

    public void Zoom(float zoomSize, float zoomDuration)
    {
        StartCoroutine(ZoomCoroutine(zoomSize, zoomDuration));
    }
    
    IEnumerator ZoomCoroutine(float zoomSize, float zoomDuration)
    {
        float time = 0;
        float startSize = vcam.m_Lens.OrthographicSize; // Store the starting size

        while (time < zoomDuration)
        {
            time += Time.deltaTime;

            // Calculate the interpolation factor
            float t = time / zoomDuration;

            // Use Mathf.Lerp to smoothly interpolate between startSize and zoomSize
            vcam.m_Lens.OrthographicSize = Mathf.Lerp(startSize, zoomSize, t);

            // Debug.Log($"{t} & {vcam.m_Lens.OrthographicSize}");
            yield return null;
        }

        // Ensure the final size is set exactly to zoomSize
        vcam.m_Lens.OrthographicSize = zoomSize;
    }
}
