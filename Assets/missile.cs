using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace DefaultNamespace
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class missile : MonoBehaviour
    {
        public Transform target;
        public float speed = 5f;
        public float rotateSpeed = 200f;
        private Rigidbody2D rb;
        public int missileDamage = 100;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            target = GameObject.FindGameObjectWithTag("Enemy").transform;

        }
        private void FixedUpdate()
        {
            Vector2 direction = (Vector2)target.position - rb.position;

            direction.Normalize();

            float rotateAmount = Vector3.Cross(direction, transform.up).z;

            rb.angularVelocity = -rotateAmount * rotateSpeed;

            rb.velocity = transform.up * speed;

        }
        private void OnTriggerEnter2D(Collider2D hitInfo)
        {
            var health = hitInfo.gameObject.GetComponent<HealthManager>();
            health?.DealDamage(missileDamage);

            Enemy enemy = hitInfo.GetComponent<Enemy>();
            if (enemy != null)
            {
                Destroy(gameObject);

            }
        }
    }
}

