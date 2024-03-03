using UnityEngine;

public class HoldPos : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    
    public void Down()
    {
        if (transform.childCount == 0) return;
        var tail = transform.GetChild(0);
        if (!tail) return;
        _spriteRenderer = _spriteRenderer == null ? tail.GetComponent<SpriteRenderer>() : _spriteRenderer;
        _spriteRenderer.sortingOrder = 12;
    }
    
    public void NotDown()
    {
        if (transform.childCount == 0) return;
        var tail = transform.GetChild(0);
        if (!tail) return;
        _spriteRenderer = _spriteRenderer == null ? tail.GetComponent<SpriteRenderer>() : _spriteRenderer;
        _spriteRenderer.sortingOrder = 0;
    }
}
