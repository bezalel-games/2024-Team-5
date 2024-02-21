using System;
using UnityEngine;

public class PlayerAnimationsManager : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    public static PlayerAnimationsManager Instance { get; private set; }
    private static readonly int Right = Animator.StringToHash("Right");
    private static readonly int Up = Animator.StringToHash("Up");
    private static readonly int UpRight = Animator.StringToHash("UpRight");
    private static readonly int Down = Animator.StringToHash("Down");
    private static readonly int DownRight = Animator.StringToHash("DownRight");
    private static readonly int ArmNumber = Animator.StringToHash("ArmNum");

    private void Awake()
    {
        Instance = Instance == null ? this : Instance;
        SetDownRightAnimation();
        StopAnimations();
    }


    public void StopAnimations()
    {
        playerAnimator.speed = 0;
    }
    
    public void StartAnimations()
    {
        playerAnimator.speed = 1;
    }
    public void SetPlayerAnimation(Vector2 dir)
    {
        switch (dir)
        {
            case { x: > 0, y: 0 }:
                SetRightAnimation();
                break;
            case { x: > 0, y: > 0 }:
                SetUpRightAnimation();
                break;
            case { x: 0, y: > 0 }:
                SetUpAnimation();
                break;
            case { x: > 0, y: < 0 }:
                SetDownRightAnimation();
                break;
            case { x: 0, y: < 0 }:
                SetDownAnimation();
                break;
            case{x: < 0, y: 0}:
                SetRightAnimation();
                break;
            case{x: < 0, y: > 0}:
                SetUpRightAnimation();
                break;
            case{x: < 0, y: < 0}:
                SetDownRightAnimation();
                break;
        }
    }

    private void SetRightAnimation()
    {
        playerAnimator.SetBool(Right, true);
        playerAnimator.SetBool(Up, false);
        playerAnimator.SetBool(UpRight, false);
        playerAnimator.SetBool(Down, false);
        playerAnimator.SetBool(DownRight, false);
        playerAnimator.SetInteger(ArmNumber, 2);
    }

    private void SetUpRightAnimation()
    {
        playerAnimator.SetBool(Right, false);
        playerAnimator.SetBool(Up, false);
        playerAnimator.SetBool(UpRight, true);
        playerAnimator.SetBool(Down, false);
        playerAnimator.SetBool(DownRight, false);
        playerAnimator.SetInteger(ArmNumber, 1);

    }

    private void SetUpAnimation()
    {
        playerAnimator.SetBool(Right, false);
        playerAnimator.SetBool(Up, true);
        playerAnimator.SetBool(UpRight, false);
        playerAnimator.SetBool(Down, false);
        playerAnimator.SetBool(DownRight, false);
        playerAnimator.SetInteger(ArmNumber, 0);

    }

    private void SetDownRightAnimation()
    {
        playerAnimator.SetBool(Right, false);
        playerAnimator.SetBool(Up, false);
        playerAnimator.SetBool(UpRight, false);
        playerAnimator.SetBool(Down, false);
        playerAnimator.SetBool(DownRight, true);
        playerAnimator.SetInteger(ArmNumber, 3);
    }

    private void SetDownAnimation()
    {
        playerAnimator.SetBool(Right, false);
        playerAnimator.SetBool(Up,false);
        playerAnimator.SetBool(UpRight,false);
        playerAnimator.SetBool(Down,true);
        playerAnimator.SetBool(DownRight, false);
        playerAnimator.SetInteger(ArmNumber, 4);
    }
}