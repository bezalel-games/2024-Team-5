using UnityEngine;
using UnityEngine.SceneManagement; 
public class ResetGame : MonoBehaviour
{
    private float resetTime = 5f * 60f; // 5 minutes in seconds
    private float lastKeyPressTime;

    private void Start()
    {
        // Initialize the last key press time to the current time at the start
        lastKeyPressTime = Time.time;
    }

    private void Update()
    {
        // Check for any key press and update the last key press time
        if (Input.anyKey)
        {
            lastKeyPressTime = Time.time;
        }

        // Check if R is pressed or if 5 minutes have passed since the last key press
        if (Input.GetKey(KeyCode.R) || (Time.time - lastKeyPressTime >= resetTime))
        {
            ResetGameScene();
        }
    }

    private void ResetGameScene()
    {
        // Replace "OpenScene" with your scene's name
        SceneManager.LoadSceneAsync("OpenScene");
    }
}