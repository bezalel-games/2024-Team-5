using UnityEngine;

    public class IsGrounded : MonoBehaviour
    {
        private bool _grounded;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                _grounded = true;
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                _grounded = false;
            }
        }
        
        public bool Grounded()
        {
            return _grounded;
        }
    }
