using System.Collections;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjectsAudioSources;
    [SerializeField] private AudioSource gameWhiteNoiseAudioSource;
    [SerializeField] private AudioSource rainSoundtrack;
    [SerializeField] private AudioSource muffeldRainSoundtrack;
    [SerializeField] private AudioSource thunderSound;
    [SerializeField] private float thunderWaitTime = 1;
    public static SoundManager Instance { get; private set; }
    
    private void Awake() {
        Instance = Instance == null ? this : Instance;
    }
    
    private void Start()
    {
        DisableSound();
    }

    public void EnableSound()
    {
        for (int i = 0; i < gameObjectsAudioSources.Length; i++)
        {
            gameObjectsAudioSources[i].GetComponent<AudioSource>().volume = 1;
        }
        gameWhiteNoiseAudioSource.volume = 0;
        
        StartCoroutine(WaitAndPlaySound());
    }
    
    public void DisableSound()
    {
        for (int i = 0; i < gameObjectsAudioSources.Length; i++)
        {
            gameObjectsAudioSources[i].GetComponent<AudioSource>().volume = 0;
        }
        gameWhiteNoiseAudioSource.volume = 0.7f;
    }
    
    private IEnumerator WaitAndPlaySound()
    {
        yield return new WaitForSeconds(thunderWaitTime);
        rainSoundtrack.Play();
        
        yield return new WaitForSeconds(thunderWaitTime);
        thunderSound.Play();
    }
}
