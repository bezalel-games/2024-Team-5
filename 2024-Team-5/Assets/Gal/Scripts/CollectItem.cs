using Hadar.Scripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gal.Scripts
{
    public class CollectItem : MonoBehaviour
    {
        [FormerlySerializedAs("playerMovment")] public PlayerMovement playerMovement;

        private void OnTriggerStay(Collider other)
        {
            if (Input.GetKeyDown(KeyCode.T) && other.gameObject.CompareTag("Collectible"))
            {
                other.transform.parent = transform; // later on needs to be specified to the body part
                // need to update properties
                playerMovement.SetByObject(other.gameObject.GetComponent<Gal.Scripts.LegObject>());
            }
        
        }
    }
}
