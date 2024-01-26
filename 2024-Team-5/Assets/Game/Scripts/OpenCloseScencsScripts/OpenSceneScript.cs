using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenSceneScript : MonoBehaviour
{
    [SerializeField] private string sceneNameToOpen; // Change to string type

    public void OpenGameScene()
    {
        SceneManager.LoadSceneAsync(sceneNameToOpen);
    }
}