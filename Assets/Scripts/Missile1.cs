using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;



namespace DefaultNamespace
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Missile1 : MonoBehaviour
    {

        private Transform _target;
        private Rigidbody2D _rb;
        private Transform _tr;
        private TrailRenderer _trail;
        [SerializeField] private float speed = 1;
        [SerializeField] private float rotateSpeed = 200f;
        [SerializeField] private int missileDamage = 100;
        [SerializeField] private GameObject deathEffect;
        


        private void Start()
        {
            _trail = GetComponent<TrailRenderer>();
            _rb = GetComponent<Rigidbody2D>();
        }

        private void OnDestroy()
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
        }

        private void FixedUpdate()
        {
            _target = FindTarget();
            if (_target != null)
            {

                Vector2 direction = (Vector2)_target.position - _rb.position;

                direction.Normalize();

                float rotateAmount = Vector3.Cross(direction, transform.up).z;

                _rb.angularVelocity = -rotateAmount * rotateSpeed;

                _rb.velocity = transform.up * speed;
            }
            else _rb.AddForce(transform.up, ForceMode2D.Force);
            if(_target == null)
            {
                _rb.angularVelocity = 0;
            }

        }

        private void OnTriggerEnter2D(Collider2D hitInfo)
        {
            Enemy enemy = hitInfo.GetComponent<Enemy>();
            if (enemy != null)
            {
                var health = hitInfo.gameObject.GetComponent<HealthManager>();
                health?.DealDamage(missileDamage);

                Destroy(gameObject);

            }
            else if(hitInfo.gameObject.tag == "Obstacle")
            {
                Destroy(gameObject);
            }
        }

        public Transform FindTarget()
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            float minDistance = Mathf.Infinity;
            Transform closest;

            if (enemies.Length == 0)
                return null;

            closest = enemies[0].transform;
            for (int i = 1; i < enemies.Length; ++i)
            {
                float distance = (enemies[i].transform.position - transform.position).sqrMagnitude;

                if (distance < minDistance)
                {
                    closest = enemies[i].transform;
                    minDistance = distance;

                }

            }

            return closest;
        }
    }
}



