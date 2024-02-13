using System.Security.Cryptography;
using UnityEngine;

public class PickupsManager : MonoBehaviour
{
    public static PickupsManager Instance { get; private set; }
    [SerializeField] private GameObject cameraPickup;
    [SerializeField] private GameObject lightPickup;
    [SerializeField] private GameObject burner;
    [SerializeField] private GameObject wheels;
    [SerializeField] private GameObject arm;
    [SerializeField] private GameObject antenna;
    [SerializeField] private PlayerMovement playerMovement;
    public GameObject pickup;
    public Transform holdPos;
    
    private bool _hasArm;
    private void Awake()
    {
        Instance = Instance == null ? this : Instance;
        // At the moment we start with an arm
    }

    private void Start()
    {
        CollectArm();
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
    
    public void CollectAntenna()
    {
        antenna.SetActive(true);
    }

    private void CollectArm()
    {
        arm.SetActive(true);
        _hasArm = true;
        ObstaclesManager.Instance.DisableRocksStatic();
        PlayerInteractions.Instance.SetHasArm(true);
    }

    public void PickUpObject(GameObject obj)
    {
        pickup = obj;
    }
    
    public void DestroyPickup(GameObject obj)
    {
        if (obj.name.Contains("Antenna"))
        {
            CollectAntenna();
        }
        else
        {
            //SoneThingELse;
        }
        Destroy(pickup);
        pickup = null;
    }
    
    public void DropObject()
    {
        pickup = null;
    }

    public bool HasArm()
    {
        return _hasArm;
    }

    public void StopMoving()
    {
        playerMovement.DisableMove();
    }
    
    public void StartMoving()
    {
        playerMovement.EnableMove();
    }
}