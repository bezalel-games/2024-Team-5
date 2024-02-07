using UnityEngine;

public class EngageElectricField : MonoBehaviour
{
    public Animator animator;
    private static readonly int StartAntenna = Animator.StringToHash("StartAntenna");
    private static readonly int StopAntenna = Animator.StringToHash("StopAntenna");

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        animator.SetTrigger(StartAntenna);
        other.gameObject.GetComponent<ControlPlayerElectricField>().StartLightning();
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        animator.SetTrigger(StopAntenna);
        other.gameObject.GetComponent<ControlPlayerElectricField>().StopLightning();

    }
}
