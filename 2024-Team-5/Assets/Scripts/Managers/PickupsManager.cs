using UnityEngine;

public class PickupsManager : MonoBehaviour
{
    public static PickupsManager Instance { get; private set; }
    [SerializeField] private GameObject cameraPickup;
    [SerializeField] private GameObject lightPickup;
    [SerializeField] private GameObject burner;
    [SerializeField] private GameObject wheels;
    [SerializeField] private GameObject arm;
    private PlayerMovement _playerMovement;
    private bool _hasArm;
    private void Awake()
    {
        Instance = Instance == null ? this : Instance;
        _playerMovement = GetComponent<PlayerMovement>();
    }

    public void CollectObject(GameObject obj)
    {
        switch (obj.name.Replace("PickUp",""))
        {
            case "Camera":
                CollectCamera();
                break;
            case "Arm":
                CollectArm();
                break;
            case "Light":
                CollectLight();
                break;
            case "Burner":
                CollectBurner();
                break;
            case "Wheels":
                CollectWheels();
                break;
        }
    }

    private void CollectWheels()
    {
        wheels.SetActive(true);
        PlayerMovement.instance.PickUpWheels();
        ObstaclesManager.Instance.DisableRamps();
    }

    private void CollectCamera()
    {
        cameraPickup.SetActive(true);
    }

    private void CollectLight()
    {
        lightPickup.SetActive(true);
    }

    public void CollectBurner()
    {
        burner.SetActive(true);
    }

    private void CollectArm()
    {
        arm.SetActive(true);
        _hasArm = true;
        ObstaclesManager.Instance.DisableRocksStatic();
    }

    public bool HasArm()
    {
        return _hasArm;
    }

    public void StopMoving()
    {
        _playerMovement.DisableMove();
    }
    
    public void StartMoving()
    {
        _playerMovement.EnableMove();
    }
}