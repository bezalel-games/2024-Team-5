using UnityEngine;

namespace Gal.Scripts
{
    public class PlayerGrows : MonoBehaviour
    {
        [SerializeField] private float growFactor = 1.5f;
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Collectible"))
            {
                Destroy(other.gameObject);
                transform.localScale += Vector3.one * growFactor;
            }
        }
    }
}
