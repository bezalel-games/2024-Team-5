using Hadar.Scripts;
using UnityEngine;

    public class CollectItem : MonoBehaviour
    {
        public PlayerMovement playerMovement;

        private Collider _currentObjectCollider;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Collectible"))
            {
                _currentObjectCollider = other;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (_currentObjectCollider == null) return;
            if (other.gameObject == _currentObjectCollider.gameObject)
            {
                _currentObjectCollider = null;
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.T) && _currentObjectCollider != null)
            {
                // _currentObjectCollider.transform.parent = transform; // later on needs to be specified to the body part
                // need to update properties
                // this is a setter to the best option available, maybe need to be changed to a combination of all properties
                playerMovement.SetByObject(_currentObjectCollider.gameObject.GetComponent<LegObject>());
                Destroy(_currentObjectCollider.gameObject);
            }
        }
    }
