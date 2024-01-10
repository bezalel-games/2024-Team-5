using UnityEngine;

namespace Gal.Scripts
{
    public class LegObject : BodyPartObject
    {
        public float speed;
        public bool canJump;
        public float jumpForce;
        public SpriteRenderer spriteRenderer;

        private void Awake()
        {
            bodyType = BodyType.Leg;
        }
    }
}

