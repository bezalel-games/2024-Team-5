using System;
using UnityEngine;

public class PlayerAnimationsManager : MonoBehaviour
{
    public HoldPos holdPos; 
    [SerializeField] private Animator playerAnimator;
    public static PlayerAnimationsManager Instance { get; private set; }
    private static readonly int Right = Animator.StringToHash("Right");
    private static readonly int Up = Animator.StringToHash("Up");
    private static readonly int UpRight = Animator.StringToHash("UpRight");
    private static readonly int Down = Animator.StringToHash("Down");
    private static readonly int DownRight = Animator.StringToHash("DownRight");
    private static readonly int ArmNumber = Animator.StringToHash("ArmNum");
    private static readonly int Antenna = Animator.StringToHash("Antenna");
    
    
    [SerializeField] private GameObject trailLeftRight;
    [SerializeField] private GameObject trailUpDown;
    [SerializeField] private GameObject trailDiagonalDown;
    [SerializeField] private GameObject trailDiagonalUp;
    [SerializeField] private SpriteRenderer renderer;
    private float timeBtwTrails;
    public float startTimeBtwTrails;
    private bool _hasWheels;
    private void Update()
    {
        CreateTrails();
    }

    private void Start()
    {
        timeBtwTrails = startTimeBtwTrails;
    }
    private void Awake()
    {
        Instance = Instance == null ? this : Instance;
        SetDownRightAnimation();
        StopAnimations();
    }
    
    public void ActivateAntenna()
    {
        playerAnimator.SetBool(Antenna, true);
        playerAnimator.speed = 1;
    }

    public void StopAnimations()
    {
        if (!playerAnimator.GetBool(Antenna)) playerAnimator.speed = 0;
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
        holdPos.NotDown();
    }

    private void SetUpRightAnimation()
    {
        playerAnimator.SetBool(Right, false);
        playerAnimator.SetBool(Up, false);
        playerAnimator.SetBool(UpRight, true);
        playerAnimator.SetBool(Down, false);
        playerAnimator.SetBool(DownRight, false);
        playerAnimator.SetInteger(ArmNumber, 1);
        holdPos.NotDown();

    }

    private void SetUpAnimation()
    {
        playerAnimator.SetBool(Right, false);
        playerAnimator.SetBool(Up, true);
        playerAnimator.SetBool(UpRight, false);
        playerAnimator.SetBool(Down, false);
        playerAnimator.SetBool(DownRight, false);
        playerAnimator.SetInteger(ArmNumber, 0);
        holdPos.NotDown();

    }

    private void SetDownRightAnimation()
    {
        playerAnimator.SetBool(Right, false);
        playerAnimator.SetBool(Up, false);
        playerAnimator.SetBool(UpRight, false);
        playerAnimator.SetBool(Down, false);
        playerAnimator.SetBool(DownRight, true);
        playerAnimator.SetInteger(ArmNumber, 3);
        holdPos.Down();
    }

    private void SetDownAnimation()
    {
        playerAnimator.SetBool(Right, false);
        playerAnimator.SetBool(Up,false);
        playerAnimator.SetBool(UpRight,false);
        playerAnimator.SetBool(Down,true);
        playerAnimator.SetBool(DownRight, false);
        playerAnimator.SetInteger(ArmNumber, 4);
        holdPos.Down();
    }

    private void CreateTrails()
    {
        if (!_hasWheels) return;
        if (timeBtwTrails <= 0)
        {
            var trail = trailLeftRight;
            switch (playerAnimator.GetInteger(ArmNumber))
            {
                case 0:
                    trail = trailUpDown;
                    break;
                case 1:
                    trail = trailDiagonalUp;
                    trail.GetComponent<SpriteRenderer>().flipX = Mathf.Sign(renderer.transform.localScale.x) < 0;
                    break;
                case 2:
                    trail = trailLeftRight;
                    break;
                case 3:
                    trail = trailDiagonalDown;
                    trail.GetComponent<SpriteRenderer>().flipX = Mathf.Sign(renderer.transform.localScale.x) < 0;
                    break;
                case 4:
                    trail = trailUpDown;
                    break;
            }
            var newTrail = Instantiate(trail, transform.position, Quaternion.identity);
            Destroy(newTrail, 0.5f);
            timeBtwTrails = startTimeBtwTrails;
        }
        else
        {
            timeBtwTrails -= Time.deltaTime;
        }
    }

    public void setWheels()
    {
        _hasWheels = true;
    }
}