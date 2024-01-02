using UnityEngine;

    public class MergeBehavior : MonoBehaviour
    {
        private HadarGameManager _gameManager;
        private PlayerMovment playerMovment;


        private void Start()
        {
            _gameManager = HadarGameManager.instance;
            playerMovment = GetComponent<PlayerMovment>();
        }

        private void OnCollisionStay(Collision collision)
        {
            if (!(_gameManager.GetActivePlayer() == collision.gameObject)) return;
            var other = collision.gameObject.GetComponent<PlayerMovment>();
            if (!other.isGrounded.Grounded() || other.GetConnected()) return;

            SetAttributes(other);
            playerMovment.SetConnection(true, other.transform);
            
        }

        private void SetAttributes(PlayerMovment other)
        {
            other.SetCanFly(playerMovment.GetCanFly() || other.GetCanFly());
            other.SetCanJump(playerMovment.GetCanJump() || other.GetCanJump());
            other.SetCanRun(playerMovment.GetCanRun() || other.GetCanRun());
        }
    }
