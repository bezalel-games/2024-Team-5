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
            }
        }

    }
}
