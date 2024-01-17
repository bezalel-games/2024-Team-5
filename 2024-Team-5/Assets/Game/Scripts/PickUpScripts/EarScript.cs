using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarScript : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.Space))
        {
            SoundManager.instance.EnableSound();
            PickupsManager.Instance.CollectEar();
            Destroy(gameObject);
        }
    }
}
