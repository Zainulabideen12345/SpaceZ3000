using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DefaultNamespace
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Kamikaze : MonoBehaviour 
    {
        [SerializeField] private float speed = 5f;
        [SerializeField] private float rotateSpeed = 200f;
        [SerializeField] private int missileDamage = 100;
        private Transform target;
        private Rigidbody2D _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            target = GameObject.FindGameObjectWithTag("Player").transform; 
        }
        private void FixedUpdate()
        {
            Flare flare = (Flare)FindObjectOfType(typeof(Flare));
            Player player = (Player)FindObjectOfType(typeof(Player));
            if (player != null)
            {
                if (flare == null)
                {
                    Vector2 direction = (Vector2)target.position - _rb.position;
                    direction.Normalize();
                    float rotateAmount = Vector3.Cross(direction, transform.up).z;
                    _rb.angularVelocity = -rotateAmount * rotateSpeed;
                    _rb.velocity = transform.up * speed;
                }
            }
            else
            {
                Vector2 direction = (Vector2)flare.gameObject.transform.position;
                direction.Normalize();
                float rotateAmount = Vector3.Cross(direction, transform.up).z;
                _rb.angularVelocity = -rotateAmount * rotateSpeed;
                _rb.velocity = transform.up * speed;
            }
        }
            
        
        private void OnTriggerEnter2D(Collider2D hitInfo)
        {
            Player player = hitInfo.GetComponent<Player>();
            if (player != null)
            {
                var health = hitInfo.gameObject.GetComponent<HealthManager>();
                health?.DealDamage(missileDamage);
                Destroy(gameObject);
            }
        
            if (hitInfo.gameObject.tag == "Obstacle" || hitInfo.gameObject.tag == "Player" || hitInfo.gameObject.tag == "Flare")
            {
                Destroy(gameObject);
            }  
        }

    }
}

