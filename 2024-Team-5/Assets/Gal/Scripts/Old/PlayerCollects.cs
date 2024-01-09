using UnityEngine;

namespace Gal.Scripts
{
    public class PlayerCollects : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            if (Input.GetKeyDown(KeyCode.T) && other.gameObject.CompareTag("Collectible"))
            {
                other.transform.parent = transform;
            }
        }
    }
}
