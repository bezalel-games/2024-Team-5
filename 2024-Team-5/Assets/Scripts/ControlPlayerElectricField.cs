
using UnityEngine;

public class ControlPlayerElectricField : MonoBehaviour
{
    [SerializeField] GameObject lightning;
    public static ControlPlayerElectricField Instance { get; private set; }
    public Animator animator;
    private static readonly int StartAntenna = Animator.StringToHash("StartAntenna");
    private static readonly int StopAntenna = Animator.StringToHash("StopAntenna");

    private void Awake()
    {
        Instance = Instance == null ? this : Instance;
    }
    public void StopLightning()
    {
        // lightning.SetActive(false);
        animator.SetTrigger("StopAntenna");

    }
    
    public void StartLightning()
    {
        animator.SetTrigger("StartAntenna");

    }
}
