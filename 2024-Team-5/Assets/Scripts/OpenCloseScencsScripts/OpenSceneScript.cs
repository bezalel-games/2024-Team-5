using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;

public class OpenSceneScript : MonoBehaviour
{
    [SerializeField] private string sceneNameToOpen;
    [SerializeField] private RawImage mainVideoDisplay;
    [SerializeField] private VideoPlayer crashVideoPlayer;
    [SerializeField] private RawImage crashVideoDisplay;
    [SerializeField] private float fadeDuration = 1f;
    [SerializeField] private GameObject button;
    private void Start()
    {
        crashVideoDisplay.color = new Color(crashVideoDisplay.color.r, crashVideoDisplay.color.g, crashVideoDisplay.color.b, 0);
    }

    public void OpenGameScene()
    {
        
        StartCoroutine(TransitionBetweenVideos());
    }

    private IEnumerator FadeTo(RawImage display, float targetAlpha, float duration)
    {
        float startAlpha = display.color.a;
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, time / duration);
            display.color = new Color(display.color.r, display.color.g, display.color.b, alpha);
            yield return null;
        }
    }

    private IEnumerator TransitionBetweenVideos()
    {
        button.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        yield return StartCoroutine(FadeTo(mainVideoDisplay, 0f, fadeDuration));
        
        crashVideoPlayer.Prepare();

        crashVideoPlayer.Play();
        yield return new WaitForSeconds(0.1f);
        yield return StartCoroutine(FadeTo(crashVideoDisplay, 1f, fadeDuration));
        

        while (crashVideoPlayer.isPlaying)
        {
            yield return null;
        }

        SceneManager.LoadSceneAsync(sceneNameToOpen);
    }
}