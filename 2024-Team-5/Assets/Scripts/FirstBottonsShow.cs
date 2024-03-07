using System.Collections;
using UnityEngine;

public class FirstButtonsShow : MonoBehaviour
{
    [SerializeField] private GameObject buttonUp;
    [SerializeField] private GameObject buttonDown;
    [SerializeField] private GameObject buttonLeft;
    [SerializeField] private GameObject buttonRight;
    [SerializeField] private GameObject buttonSpace;
    [SerializeField] private GameObject spaceText;
    [SerializeField] private GameObject walkText;
    [SerializeField] private GameObject resetText;

    private float timeDelay = 15f; // You might want to remove or adjust this if it's no longer needed
    private float gameStartTime;
    private bool resetActivated = false; // To ensure the reset activation happens only once

    void Start()
    {
        gameStartTime = Time.time; // Capture the start time of the game
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            StartCoroutine(FadeOutSprite(buttonUp));
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            StartCoroutine(FadeOutSprite(buttonDown));
            StartCoroutine(FadeOutSprite(walkText));
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            StartCoroutine(FadeOutSprite(buttonLeft));
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            StartCoroutine(FadeOutSprite(buttonRight));
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(FadeOutSprite(buttonSpace));
            StartCoroutine(FadeOutSprite(spaceText));
        }

        // New logic to activate the reset text after 20 seconds from the game start
        if (!resetActivated && Time.time - gameStartTime >= 50f)
        {
            resetText.SetActive(true); // This activates the resetText object
            resetActivated = true; // Ensure it doesn't activate more than once
        }
        
    }

    IEnumerator FadeOutSprite(GameObject target)
    {
        if (target != null)
        {
            SpriteRenderer spriteRenderer = target.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                float duration = 1f; // Duration in seconds
                float currentTime = 0f;
                Color startColor = spriteRenderer.color;
                while (currentTime < duration)
                {
                    currentTime += Time.deltaTime;
                    float alpha = Mathf.Lerp(startColor.a, 0, currentTime / duration);
                    spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
                    yield return null; // Wait for a frame
                }
                spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, 0); // Ensure it's fully transparent
                target.SetActive(false); // Optionally deactivate the object
            }
        }
    }
}
