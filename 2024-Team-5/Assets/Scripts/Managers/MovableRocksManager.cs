using UnityEngine;

public class MovableRocksManager : MonoBehaviour
{
    [SerializeField] private MovableRock[] rocks;

    public static MovableRocksManager Instance { get; private set; }
    
    private void Awake()
    {
        Instance = Instance == null ? this : Instance;
    }

    
    public void EnableMoveRocks()
    {
        foreach (var rock in rocks)
        {
            rock.EnableRock();
        }
    }

}

