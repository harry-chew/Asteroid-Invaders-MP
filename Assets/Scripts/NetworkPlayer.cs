using Unity.Netcode;
using UnityEngine;

namespace AsteroidInvaders
{
    public class NetworkPlayer : NetworkBehaviour
    {
        [Header("Movement")]
        [Range(0f, 1f)]
        public float moveForce;
        [Range(500f, 1500f)]
        public float moveForceMultiplier = 1000f;

        [Space(10)]
        [Header("Shooting")]
        public GameObject bulletPrefab;

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

            if (Input.GetMouseButtonDown(0))
            {
                ShootClientRpc();
            }
        }

        [ClientRpc]
        private void ShootClientRpc()
        {
            GameObject go = Instantiate(bulletPrefab, transform.position + Vector3.up, Quaternion.identity, null);
            Destroy(go, 1f);
        }

        private void FixedUpdate()
        {
            if (!IsOwner)
                return;

            rb.AddForce(moveForce * moveForceMultiplier * Time.fixedDeltaTime * moveDir);
        }
    }
}
