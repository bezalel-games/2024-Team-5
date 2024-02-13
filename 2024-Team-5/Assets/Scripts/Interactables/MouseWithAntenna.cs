using UnityEngine;

public class MouseWithAntenna : SwitchableObject
{
    public bool hasAntenna;
    [SerializeField] private Sprite[] beforeSprites;
    [SerializeField] private Sprite[] afterSprites;
    [SerializeField] private Transform holder;
    [SerializeField] private Transform path;
    
    private Sprite[] currentSprites;
    private SpriteRenderer _renderer;
    private float lastX;
    private float lastY;

    [SerializeField] private int currentPathIndex;
    public float speed;
    private Vector3 lastPosition;

    private void Start()
    {
        currentSprites = hasAntenna ? beforeSprites : afterSprites;
        _renderer = GetComponentInChildren<SpriteRenderer>();
        lastPosition = holder.transform.position;
    }

    [ContextMenu("Switch")]
    protected override void Switch()
    {
        if (!hasAntenna) return;
        base.Switch();
        Debug.Log("Switched");
        currentSprites = afterSprites;
    }

    private void Update()
    {
        base.Update();
        Move();
        Vector3 currentPosition = holder.transform.position;

        float threshold = 0.01f; // Define your threshold value here

        if (currentPosition.y - lastPosition.y > threshold)
        {
            _renderer.sprite = currentSprites[1];
            _renderer.flipX = true;
        }
        else if (lastPosition.y - currentPosition.y > threshold)
        {
            _renderer.sprite = currentSprites[0];
            _renderer.flipX = false;
        }
        
        if (currentPosition.x - lastPosition.x > threshold)
        {
            _renderer.flipX = true;
        }
        else if (lastPosition.x - currentPosition.x > threshold)
        {
            _renderer.flipX = false;
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