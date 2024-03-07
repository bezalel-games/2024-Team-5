using UnityEngine;
using System.Collections;

public class PlayAudioEveryXSeconds : MonoBehaviour
{
    [SerializeField] float delay = 5f; 
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        StartCoroutine(PlaySoundWithDelay(delay));
    }

    IEnumerator PlaySoundWithDelay(float delay)
    {
        // Loop indefinitely
        while (true)
        {
            // Play the audio
            audioSource.Play();

            // Wait for X seconds before playing again
            yield return new WaitForSeconds(delay);
        }
    }
}