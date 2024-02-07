using UnityEngine;

public class PickupsManager : MonoBehaviour
{
    public static PickupsManager Instance { get; private set; }
    [SerializeField] private GameObject antenaPickup;
    [SerializeField] private GameObject lightPickup;
    [SerializeField] private GameObject burner;
    [SerializeField] private GameObject wheels;
    private PlayerMovement _playerMovement;
    
    private void Awake()
    {
        Instance = Instance == null ? this : Instance;
        _playerMovement = GetComponent<PlayerMovement>();
    }

    public void CollectObject(GameObject obj)
    {
        switch (obj.name.Replace("PickUp",""))
        {
            case "Antena":
                CollectAntenna();
                break;
            case "Arm":
                // TODO: CollectArm();
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
    }

    private void CollectAntenna()
    {
        antenaPickup.SetActive(true);
    }

    private void CollectLight()
    {
        lightPickup.SetActive(true);
    }

    public void CollectBurner()
    {
        burner.SetActive(true);
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