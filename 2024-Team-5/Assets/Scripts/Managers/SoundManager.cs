using System.Collections;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjectsAudioSources;
    [SerializeField] private AudioSource gameWhiteNoiseAudioSource;
    [SerializeField] private AudioSource rainSoundtrack;
    [SerializeField] private AudioSource thunderSound;
    [SerializeField] private float thunderWaitTime = 1;
    [SerializeField] private AudioSource connectSound;
    [SerializeField] private AudioSource wheelsSound;
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
        
    }
    
    public void DisableSound()
    {
        for (int i = 0; i < gameObjectsAudioSources.Length; i++)
        {
            gameObjectsAudioSources[i].GetComponent<AudioSource>().volume = 0;
        }
        gameWhiteNoiseAudioSource.volume = 0.1f;
    }
    
    
    public void PlayConnectSound()
    {
        connectSound.Play();
    }
    
    public void PlayWheelsSound()
    {
        if (wheelsSound.isPlaying) return;
        wheelsSound.Play();
    }
}
