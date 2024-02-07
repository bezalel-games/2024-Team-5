using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TeleportPlayerToFromCave : MonoBehaviour
{
    private static bool inCave = false;
    [SerializeField] private Vector2 EnterCavePosition;
    [SerializeField] private Vector2 ExitCavePosition;
    [SerializeField] private Light2D gameLight;
    [SerializeField] private float transitionDuration = 1f;
    [SerializeField] private float delayDurationAfterTurnBlack = 0.7f; // 1 second delay
    [SerializeField] float caveLightIntensity = 0.05f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered");
        Debug.Log(inCave);
        if (other.CompareTag("Player"))
        {
            StartCoroutine(TeleportPlayer(other.transform));
        }
    }

    private IEnumerator TeleportPlayer(Transform playerTransform)
    {
        // Fade out the light
        float elapsedTime = 0f;
        float startIntensity = gameLight.intensity;
        while (elapsedTime < transitionDuration)
        {
            elapsedTime += Time.deltaTime;
            gameLight.intensity = Mathf.Lerp(startIntensity, 0f, elapsedTime / transitionDuration);
            yield return null;
        }
        
        // Teleport the player
        inCave = !inCave;
        playerTransform.position = inCave ? ExitCavePosition : EnterCavePosition;
        
        // Wait for 1 second with intensity 0
        yield return new WaitForSeconds(delayDurationAfterTurnBlack);

        if (inCave)
        {
            // Fade in the light
            elapsedTime = 0f;
            while (gameLight.intensity<caveLightIntensity)
            {
                elapsedTime += Time.deltaTime;
                gameLight.intensity = Mathf.Lerp(0f, startIntensity, elapsedTime / transitionDuration);
                yield return null;
            }
        }
        else
        {
            elapsedTime = 0f;
            while (elapsedTime < transitionDuration)
            {
                elapsedTime += Time.deltaTime;
                gameLight.intensity = Mathf.Lerp(0f, 1, elapsedTime / transitionDuration);
                yield return null;
            }
            gameLight.intensity = 1; // Ensure light intensity is back to original value
        }
    }
}