using UnityEngine;

namespace Gal.Scripts
{
    public class PlayerGrows : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Collectible"))
            {
                Destroy(other.gameObject);
                transform.localScale += Vector3.one * 0.1f;
            }
        }
    }
}
