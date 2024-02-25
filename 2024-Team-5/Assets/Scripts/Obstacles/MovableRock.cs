using UnityEngine;

public class MovableRock : Obstacle
{
    protected Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public override void RemoveObstacle()
    {
        EnableRock();
    }
    
    public void EnableRock()
    {
        if(!rb) rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
}