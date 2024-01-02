using UnityEngine;

namespace Gal.Scripts
{
    public class PlayerGal : MonoBehaviour
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
