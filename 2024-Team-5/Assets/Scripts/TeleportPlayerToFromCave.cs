using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TeleportPlayerToFromCave : MonoBehaviour
{
    private static bool inCave = false;
    [SerializeField] private GameObject EnterCaveObject;
    [SerializeField] private GameObject ExitCaveObject;
    [SerializeField] private Light2D gameLight;
    [SerializeField] private float transitionDuration = 1f;
    [SerializeField] private float delayDurationAfterTurnBlack = 0.7f;
    [SerializeField] float caveLightIntensity = 0.00f;
    [SerializeField] private GameObject PlayerLight;
    [SerializeField] private GameObject light;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement.instance.DisableMove();
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
        playerTransform.position = inCave ? ExitCaveObject.transform.position : EnterCaveObject.transform.position;

        // Wait for 1 second with intensity 0
        yield return new WaitForSeconds(delayDurationAfterTurnBlack);

        if (inCave)
        {
            SwitchCaveGameSound.Instance.SwitchCaveGameSounds();
            // Fade in the light
            elapsedTime = 0f;
            while (gameLight.intensity < caveLightIntensity)
            {
                elapsedTime += Time.deltaTime;
                gameLight.intensity = Mathf.Lerp(0f, startIntensity, elapsedTime / transitionDuration);
                yield return null;
            }

            if (PlayerLight.activeSelf)
            {
                light.SetActive(true);
            }
        }
        else
        {
            SwitchCaveGameSound.Instance.SwitchCaveGameSounds();
            elapsedTime = 0f;
            while (elapsedTime < transitionDuration)
            {
                elapsedTime += Time.deltaTime;
                gameLight.intensity = Mathf.Lerp(0f, 1, elapsedTime / transitionDuration);
                yield return null;
            }

            gameLight.intensity = 1; // Ensure light intensity is back to original value
            if (PlayerLight.activeSelf)
            {
                light.SetActive(false);
            }
        }

        PlayerMovement.instance.EnableMove();
    }
}