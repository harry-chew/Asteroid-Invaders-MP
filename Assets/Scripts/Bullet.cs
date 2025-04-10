using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AsteroidInvaders
{
    public class Bullet : MonoBehaviour
    {
        private Rigidbody2D rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            rb.AddForce(transform.up * 100f);
        }
    }
}
