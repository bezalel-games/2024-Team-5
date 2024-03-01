using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GoToEndScene : MonoBehaviour
{
    public static GoToEndScene instance;
    public RawImage fadeImage; // Ensure this is set in the inspector.
    public float duration = 4f; // Duration of the fade in seconds.

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
        float currentTime = 0f;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            // Interpolate alpha from 0 (fully transparent) to 1 (fully opaque).
            float alpha = Mathf.Lerp(0f, 1f, currentTime / duration);
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, alpha);
            yield return null;
        }

        // Once the effect is complete, load the next scene.
        SceneManager.LoadSceneAsync("EndScene");
    }
    
}