
using UnityEngine;

public class CaveEnterColider : MonoBehaviour

{
    public static CaveEnterColider insatnce;

    private void Awake()
    {
        insatnce = this;
    }

    public void destroyCaveEnterCollider()
    {
        Destroy(this.gameObject);
    }
}