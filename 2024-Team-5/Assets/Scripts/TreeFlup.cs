using UnityEngine;

public class TreeFlup : MonoBehaviour, INteractable
{
    [SerializeField] private Animator animator;
    private static readonly int Flup = Animator.StringToHash("Flup");
    public AudioSource flupSound;

    public void Interact()
    {
        animator.SetTrigger(Flup);
        
    }
    
    /**
     * set by animation event
     */
    public void PlayFlupSound()
    {
        flupSound.Play();
    }
}
