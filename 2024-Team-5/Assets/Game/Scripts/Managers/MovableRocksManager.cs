using UnityEngine;

namespace Game.Scripts.Managers
{
    public class MovableRocksManager : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D[] rocksRigidbodies;
    
        public static MovableRocksManager Instance { get; private set; }
        
        private void Awake()
        {
            Instance = Instance == null ? this : Instance;
        }

        // once the player has wheels, the rocks can be moved
        public void EnableMoveRocks()
        {
            for (int i = 0; i < rocksRigidbodies.Length; i++)
            {
                rocksRigidbodies[i].bodyType = RigidbodyType2D.Dynamic;
                rocksRigidbodies[i].gravityScale = 0;
                rocksRigidbodies[i].mass = Random.Range(1,2);
                rocksRigidbodies[i].angularDrag = Random.Range(1,1.5f);
                rocksRigidbodies[i].drag = Random.Range(0.7f, 1.2f);
            }
        }

    }
}
