using System;
using Hadar.Scripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gal.Scripts
{
    public class CollectItem : MonoBehaviour
    {
        [FormerlySerializedAs("playerMovment")]
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
            if (other.gameObject.CompareTag("Collectible"))
            {
                _currentObjectCollider = null;
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.T) && _currentObjectCollider != null)
            {
                _currentObjectCollider.transform.parent = transform; // later on needs to be specified to the body part
                // need to update properties
                playerMovement.SetByObject(_currentObjectCollider.gameObject.GetComponent<Gal.Scripts.LegObject>());
            }
        }
    }
}