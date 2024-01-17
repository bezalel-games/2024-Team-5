using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjectsAudioSources;
    [SerializeField] private AudioSource gameWhiteNoiseAudioSource;
    [SerializeField] private float soundVolumeEpsilon;
    public static SoundManager instance;
    void Awake() {
        instance = this;
    }
    
    private void Start()
    {
        DisableSound();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            Debug.Log("play/pause sound");
            if (gameWhiteNoiseAudioSource.volume != soundVolumeEpsilon)
            {
                EnableSound();
            }
            else
            {
                DisableSound();
            }
        }
    }

    public void EnableSound()
    {
        Debug.Log("EnableSound");
        for (int i = 0; i < gameObjectsAudioSources.Length; i++)
        {
            gameObjectsAudioSources[i].GetComponent<AudioSource>().volume = 1;
        }
        gameWhiteNoiseAudioSource.volume = soundVolumeEpsilon;
    }
    
    public void DisableSound()
    {
        Debug.Log("DisableSound");
        for (int i = 0; i < gameObjectsAudioSources.Length; i++)
        {
            gameObjectsAudioSources[i].GetComponent<AudioSource>().volume = soundVolumeEpsilon;
        }
        gameWhiteNoiseAudioSource.volume = 0.7f;
    }
}
