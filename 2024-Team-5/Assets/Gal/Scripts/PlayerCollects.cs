using UnityEngine;

namespace Gal.Scripts
{
    public class PlayerCollects : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Collectible"))
            {
                other.transform.parent = transform;
            }
        }
    }
}
