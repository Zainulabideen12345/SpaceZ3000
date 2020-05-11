using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DefaultNamespace
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Missile : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float speed = 5f;
        [SerializeField] private float rotateSpeed = 200f;
        [SerializeField] private int missileDamage = 100;

        private Rigidbody2D _rb;

        private void Start()
        {
           _rb = GetComponent<Rigidbody2D>();
            target = GameObject.FindGameObjectWithTag("Enemy").transform;
        }
        private void FixedUpdate()
        {
            Enemy enemy = (Enemy)FindObjectOfType(typeof(Enemy));
            if (enemy != null)
            {
                Vector2 direction = (Vector2)target.position - _rb.position;

                direction.Normalize();

                float rotateAmount = Vector3.Cross(direction, transform.up).z;

                _rb.angularVelocity = -rotateAmount * rotateSpeed;

                _rb.velocity = transform.up * speed;
            }
            else _rb.AddForce(transform.up,ForceMode2D.Impulse);
            
            

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
            if(hitInfo.gameObject.tag == "Obstacle")
            {
                Destroy(gameObject);
            }
        }
        
    }
}

