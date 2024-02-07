using UnityEngine;

public class MovableRock : Obstacle
{
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public override void RemoveObstacle()
    {
        EnableRock();
    }
    
    public void EnableRock()
    {
        _rb.bodyType = RigidbodyType2D.Dynamic;
    }
}