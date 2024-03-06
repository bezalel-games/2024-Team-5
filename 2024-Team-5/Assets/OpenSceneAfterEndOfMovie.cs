using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video; // Import the Video namespace
using UnityEngine.SceneManagement; // Import the SceneManagement namespace

public class OpenSceneAfterEndOfMovie : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Reference to the VideoPlayer component

    // Start is called before the first frame update
    void Start()
    {
        // Ensure videoPlayer is not null
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }

        if (videoPlayer != null)
        {
            // Add a listener to call the OnMovieFinished function when the movie ends
            videoPlayer.loopPointReached += OnMovieFinished;
        }
    }

    void OnMovieFinished(VideoPlayer vp)
    {
        // Asynchronously load the scene when the video finishes
        SceneManager.LoadSceneAsync("OpenScene");
    }

}