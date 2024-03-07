using UnityEngine;

public class TreeFlup : Interactable
{
    [SerializeField] private Animator animator;
    private static readonly int Flup = Animator.StringToHash("Flup");


    public override void Interact()
    {
        animator.SetTrigger(Flup);
    }

}
