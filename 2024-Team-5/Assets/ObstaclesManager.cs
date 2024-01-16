using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesManager : MonoBehaviour
{
    public static ObstaclesManager Instance { get; private set; }
    
    public GameObject[] obstacles; 
    private void Awake()
    {
        Instance = Instance == null ? this : Instance;
    }

    public void DisableObstacles()
    {
        foreach (var obstacle in obstacles)
        {
            obstacle.SetActive(false);
        }
    }
}
