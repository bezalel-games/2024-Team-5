
using UnityEngine;
using UnityEngine.Video; // Import the Video namespace
using UnityEngine.SceneManagement; // Import the SceneManagement namespace

public class OpenSceneAfterEndOfMovie : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Reference to the VideoPlayer component

    void Start()
    {
        // Ensure videoPlayer is not null
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }

        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += OnMovieFinished;
        }
    }

    void OnMovieFinished(VideoPlayer vp)
    {
        SceneManager.LoadSceneAsync("OpenScene");
    }

}