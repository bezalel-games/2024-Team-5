using System;
using UnityEngine;

public class PickupsManager : MonoBehaviour
{
    public static PickupsManager Instance { get; private set; }
    [SerializeField] private Sprite goodEyeSprite;
    [SerializeField] private SpriteRenderer bodyRenderer;
    [SerializeField] private GameObject ear;
    [SerializeField] private GameObject lightPickup;
    [SerializeField] private GameObject burner;
    
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
            case "Eye":
                CollectEye();
                break;
            case "Ear":
                CollectEar();
                break;
            case "Light":
                CollectLight();
                break;
            case "Burner":
                CollectBurner();
                break;
        }
    }

    private void CollectEye()
    {
        bodyRenderer.sprite = goodEyeSprite;
    }

    public void CollectEar()
    {
        ear.SetActive(true);
    }

    public void CollectLight()
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