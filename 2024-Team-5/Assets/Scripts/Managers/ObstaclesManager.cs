using UnityEngine;

public class ObstaclesManager : MonoBehaviour
{
    public static ObstaclesManager Instance { get; private set; }
    
    public Obstacle[] ramps; 
    public Obstacle[] rocks; 
    private void Awake()
    {
        Instance = Instance == null ? this : Instance;
    }
    
    public void DisableRocksStatic()
    {
        foreach (var obstacle in rocks)
        {
            obstacle.RemoveObstacle();
        }
    }
    
    public void DisableRamps()
    {
        foreach (var obstacle in ramps)
        {
            obstacle.RemoveObstacle();
        }
    }
}
