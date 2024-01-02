using UnityEngine;

namespace Gal.Scripts
{
    public class PlayerMoves : MonoBehaviour
    {
        [SerializeField] private float speed = 1f;

        private void Update()
        {
            if (Input.GetKey(KeyCode.RightArrow)){
                transform.position += Vector3.right * (speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftArrow)){
                transform.position += Vector3.left * (speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.UpArrow)){
                transform.position += Vector3.forward * (speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.DownArrow)){
                transform.position += Vector3.back * (speed * Time.deltaTime);
            }
        }
        
   
    }
}
