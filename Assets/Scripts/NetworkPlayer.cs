using Unity.Netcode;
using UnityEngine;

namespace AsteroidInvaders
{
    public class NetworkPlayer : NetworkBehaviour
    {
        public float moveSpeed;

        private Vector2 moveDir;
        private Rigidbody2D rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            moveDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }

        private void FixedUpdate()
        {
            rb.AddForce(moveSpeed * Time.fixedDeltaTime  * moveDir);
        }
    }
}
