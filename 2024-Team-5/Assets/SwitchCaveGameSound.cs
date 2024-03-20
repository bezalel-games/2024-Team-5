using System.Collections;
using UnityEngine;

public class SwitchCaveGameSound : MonoBehaviour
{
    // Singleton instance
    public static SwitchCaveGameSound Instance { get; private set; }

    public AudioSource[] audioSources;
    private int currentAudioSourceIndex = 0;

    [SerializeField]
    private float fadeDuration = 0.5f; // Duration of the fade in seconds

    void Awake()
    {
        // Implement the singleton pattern
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Get the AudioSource components
        audioSources = GetComponents<AudioSource>();
        if (audioSources.Length < 2)
        {
            Debug.LogWarning("SwitchCaveGameSound expects exactly 2 AudioSource components on the GameObject.");
        }
    }
    
    public void SwitchCaveGameSounds()
    {
        // Ensure we have at least two audio sources
        if (audioSources.Length >= 2)
        {
            // Fade out the currently playing audio source and fade in the next
            StartCoroutine(FadeAudioSources(currentAudioSourceIndex, (currentAudioSourceIndex + 1) % audioSources.Length));
        }
        else
        {
            Debug.LogError("Not enough audio sources to switch.");
        }
    }

    private IEnumerator FadeAudioSources(int fadeOutIndex, int fadeInIndex)
    {
        float currentTime = 0;
        
        // Start both sources playing (fadeIn source might be silent due to volume=0)
        if (!audioSources[fadeInIndex].isPlaying)
            audioSources[fadeInIndex].Play();

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            float t = currentTime / fadeDuration;
            
            // Fade out the current source
            audioSources[fadeOutIndex].volume = Mathf.Lerp(1.0f, 0.0f, t);
            // Fade in the next source
            audioSources[fadeInIndex].volume = Mathf.Lerp(0.0f, 1.0f, t);
            yield return null;
        }

        // Ensure the faded out source is stopped and volume is reset for future plays
        audioSources[fadeOutIndex].Stop();
        audioSources[fadeOutIndex].volume = 1.0f;

        // Update the current audio source index
        currentAudioSourceIndex = fadeInIndex;
    }
}
