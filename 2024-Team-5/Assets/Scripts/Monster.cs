using System;
using UnityEngine;

public class Monster : Interactable
{
    public bool hasFlashlight;
    public GameObject flashlight;
    private bool _mouthOpen;
    private Animator _anim;
    private static readonly int HasFlashlight = Animator.StringToHash("HasFlashlight");
    private static readonly int In = Animator.StringToHash("OpenClose");
    
    public override void Interact()
    {
        if (!_mouthOpen || !hasFlashlight) return;
        flashlight.SetActive(true);
        // PickupsManager.Instance.CollectLight();
        hasFlashlight = false;
        _anim.SetBool(HasFlashlight, false);
        ControlMiceAppearanceScript.Instance.ChangeMiceAppearance();
    }

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _anim.SetBool(HasFlashlight, hasFlashlight);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        _anim.SetBool(In, true);
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        _anim.SetBool(In, false);
    }
    
    /**
     * This method is called animation event. 1 = True, 0 = False
     */
    public void SetMouthState(int state)
    {
        _mouthOpen = state == 1;
    }
}
