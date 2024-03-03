using UnityEngine;

public class caveEntrance : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name != "Mouse") return;
        Destroy(other.transform.parent.parent.gameObject);
    }
}
