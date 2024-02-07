using System.Collections;
using UnityEngine;

public class caveEntrance : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Mouse")
        {
            var sprite = other.GetComponent<SpriteRenderer>();
            if (sprite != null)
            {
                StartCoroutine(SetTransperacy(sprite));
            }
        }
    }
    
    IEnumerator SetTransperacy(SpriteRenderer other)
    {
        for (float f = 1f; f >= 0; f -= 0.1f)
        {
            other.color = new Color(1,1,1,f);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
