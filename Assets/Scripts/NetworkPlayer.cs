using Unity.Netcode;
using UnityEngine;

namespace AsteroidInvaders
{
    public class NetworkPlayer : NetworkBehaviour
    {
        [Range(0f, 1f)]
        public float moveForce;
        [Range(500f, 1500f)]
        public float moveForceMultiplier = 1000f;

        private Vector2 moveDir;
        private Rigidbody2D rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (!IsOwner)
                return;

            moveDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }

        private void FixedUpdate()
        {
            if (!IsOwner)
                return;

            rb.AddForce(moveForce * moveForceMultiplier * Time.fixedDeltaTime * moveDir);
        }
    }
}
