using UnityEngine;

public class MouseWithAntenna : SwitchableObject
{
    public bool hasAntenna;
    [SerializeField] private Sprite[] beforeSprites;
    [SerializeField] private Sprite[] afterSprites;
    [SerializeField] private Transform holder;
    [SerializeField] private Transform path;
    
    private SpriteRenderer _renderer;
    private float lastX;
    private float lastY;
    private Animator _animator;
    [SerializeField] private int currentPathIndex;
    public float speed;
    private Vector3 lastPosition;
    private static readonly int Up = Animator.StringToHash("Up");
    private static readonly int StarParameter = Animator.StringToHash("Star");

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _renderer = GetComponentInChildren<SpriteRenderer>();
        lastPosition = holder.transform.position;
        _animator.SetBool(StarParameter,!hasAntenna);
    }

    [ContextMenu("Switch")]
    protected override void Switch()
    {
        if (!hasAntenna || !PickupsManager.Instance.HasTail()) return;
        Debug.Log("Switched");
        base.Switch();
        _animator.SetBool(StarParameter,true);
    }

    private void Update()
    {
        base.Update();
        Move();
        Vector3 currentPosition = holder.transform.position;

        float threshold = 0.001f; // Define your threshold value here

        if (currentPosition.y - lastPosition.y > threshold)
        {
           _animator.SetBool(Up, true);
            _renderer.flipX = false;
        }
        else if (lastPosition.y - currentPosition.y > threshold)
        {
            _animator.SetBool(Up, false);
            _renderer.flipX = true;
        }
        
        if (currentPosition.x - lastPosition.x > threshold)
        {
            _renderer.flipX = false;
        }
        else if (lastPosition.x - currentPosition.x > threshold)
        {
            _renderer.flipX = true;
        }

        lastPosition = currentPosition;
    }

    private void Move()
    {
        if (Vector3.Distance(holder.transform.position, path.GetChild(currentPathIndex).position) < 0.01f)
        {
            currentPathIndex++;
            if (currentPathIndex >= 4)
                currentPathIndex = 0;
        }

        holder.transform.position = Vector3.MoveTowards(holder.transform.position,
            path.GetChild(currentPathIndex).position, speed * Time.deltaTime);
    }
}