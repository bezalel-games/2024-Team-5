using UnityEngine;

public class SwitchableObject : MonoBehaviour
{
    public GameObject player;
    
    protected void Update()
    {
        // if (player && Input.GetKeyDown(KeyCode.Space))
        // {
        //     Switch();
        // }
    }

    protected virtual void Switch()
    {
        PickupsManager.Instance.UsePickup(gameObject);
    }
    
}