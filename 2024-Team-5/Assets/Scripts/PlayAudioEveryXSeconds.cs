using UnityEngine;
using System.Collections;

public class PlayAudioEveryXSeconds : MonoBehaviour
{
    [SerializeField] float delay = 5f; // Time in seconds between each play. Adjust this value in the Inspector.

    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component from the same GameObject this script is attached to
        audioSource = GetComponent<AudioSource>();

        // Start the coroutine that plays the sound every X seconds
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