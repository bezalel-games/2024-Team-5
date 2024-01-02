using UnityEngine;

namespace Gal.Scripts
{
    public class PlayerGal : MonoBehaviour
    {
        private readonly float _speed = 2.0f;

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.RightArrow)){
                transform.position += Vector3.right * (_speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftArrow)){
                transform.position += Vector3.left * (_speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.UpArrow)){
                transform.position += Vector3.forward * (_speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.DownArrow)){
                transform.position += Vector3.back * (_speed * Time.deltaTime);
            }
        }
        
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Collectible"))
            {
                Destroy(gameObject);
            }
        }
    }
}
