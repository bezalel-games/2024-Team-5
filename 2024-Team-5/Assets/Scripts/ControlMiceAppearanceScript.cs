
using UnityEngine;

public class ControlMiceAppearanceScript : MonoBehaviour
{
    public static ControlMiceAppearanceScript Instance { get; private set; }
    [SerializeField] private GameObject mouses;

    private void Awake()
    {
        Instance = Instance == null ? this : Instance;
    }

    public void ShowMice()
    {
        mouses.SetActive(true);
    }
    
}
