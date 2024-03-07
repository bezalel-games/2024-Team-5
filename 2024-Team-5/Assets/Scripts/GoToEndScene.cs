using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using Cinemachine;

public class GoToEndScene : MonoBehaviour
{
    public static GoToEndScene instance;
    public RawImage fadeImage; // Ensure this is set in the inspector.
    public CinemachineVirtualCamera camera; // Assign your main camera in the inspector.
    public float duration = 4f; // Duration of the fade and zoom in seconds.
    public float startFOV = 8f; // Starting field of view, adjust as needed.
    public float endFOV = 4f; // Ending field of view for zoom effect, adjust as needed.
    public float delayBeforeStart = 1f;

    private void Awake()
    {
        instance = this;
    }

    public void StartFadeOut()
    {
        StartCoroutine(FadeOutEffect());
    }

    IEnumerator FadeOutEffect()
    {
        yield return new WaitForSeconds(delayBeforeStart);
        float currentTime = 0f;
        camera.m_Lens.OrthographicSize = startFOV;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            // Interpolate alpha from 0 (fully transparent) to 1 (fully opaque).
            float alpha = Mathf.Lerp(0f, 1f, currentTime / duration);
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, alpha);
            // Simultaneously, adjust the camera's FOV to zoom in.
            camera.m_Lens.OrthographicSize = Mathf.Lerp(startFOV, endFOV, currentTime / duration);
            yield return null;
        }

        // Once the effect is complete, load the next scene.
        SceneManager.LoadSceneAsync("EndScene");
    }
}