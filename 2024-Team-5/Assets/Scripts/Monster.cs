using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Monster : Interactable
{
    public bool hasFlashlight;
    public GameObject flashlight;
    public Animator radar;
    private bool _mouthOpen;
    private Animator _anim;
    private static readonly int HasFlashlight = Animator.StringToHash("HasFlashlight");
    private static readonly int In = Animator.StringToHash("OpenClose");
    private static readonly int StartAntenna = Animator.StringToHash("StartAntenna");
    private static readonly int StopAntenna = Animator.StringToHash("StopAntenna");
    [SerializeField] private Animator radarAnim;
    public override void Interact()
    {
        if (!_mouthOpen || !hasFlashlight) return;
        flashlight.SetActive(true);
        // PickupsManager.Instance.CollectLight();
        hasFlashlight = false;
        _anim.SetBool(HasFlashlight, false);
        radar.SetTrigger(StopAntenna);
        radarAnim.gameObject.GetComponent<ControlPlayerElectricField>().StopLightning();
    }

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _anim.SetBool(HasFlashlight, hasFlashlight);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        radarAnim = other.GetComponent<Animator>();
        _anim.SetBool(In, true);
        if (hasFlashlight)
        {
            radar.SetTrigger(StartAntenna);
            other.gameObject.GetComponent<ControlPlayerElectricField>().StartLightning();
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        _anim.SetBool(In, false);
        if (hasFlashlight)
        {
            radar.SetTrigger(StopAntenna);
            other.gameObject.GetComponent<ControlPlayerElectricField>().StopLightning();
        }
    }
    
    /**
     * This method is called animation event. 1 = True, 0 = False
     */
    public void SetMouthState(int state)
    {
        _mouthOpen = state == 1;
    }
}
