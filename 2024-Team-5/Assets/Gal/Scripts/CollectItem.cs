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
            if (!Input.GetKeyDown(KeyCode.T) || _currentObjectCollider == null) return;
            var bodyPartObject = _currentObjectCollider.gameObject.GetComponent<BodyPartObject>();
            if (bodyPartObject != null)
            {
                Debug.Log("collected");
                playerMovement.SetByObject(bodyPartObject);
            }
            
            Destroy(_currentObjectCollider.gameObject);
        }
    }
