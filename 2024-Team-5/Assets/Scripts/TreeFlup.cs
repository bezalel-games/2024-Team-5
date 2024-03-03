using UnityEngine;

public class TreeFlup : Interactable
{
    [SerializeField] private Animator animator;
    private static readonly int Flup = Animator.StringToHash("Flup");


    public override void Interact()
    {
        animator.SetTrigger(Flup);
    }
    
    // private void OnCollisionStay2D(Collision2D other)
    // {
    //     if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space))
    //     {
    //         animator.SetTrigger("Flup");
    //     }
    //   
    // }
    
}
