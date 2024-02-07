using UnityEngine;

public class ObstaclesManager : MonoBehaviour
{
    public static ObstaclesManager Instance { get; private set; }
    
    public Obstacle[] obstacles; 
    private void Awake()
    {
        Instance = Instance == null ? this : Instance;
    }

    public void DisableObstacles()
    {
        foreach (var obstacle in obstacles)
        {
            obstacle.RemoveObstacle();
        }
    }
}
