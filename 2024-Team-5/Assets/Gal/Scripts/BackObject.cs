using UnityEngine;

public class BackObject : BodyPartObject
{
    public bool canFly;
    public SpriteRenderer spriteRenderer;

    private void Awake()
    {
        bodyType = BodyType.Back;
    }
}

