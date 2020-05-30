using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.Impl;

namespace DefaultNamespace
{
    public class PlayerBullet : MonoBehaviour
    {
        [SerializeField] private int damageValue = 50;
        [SerializeField] private int moveSpeed = 5;
        private Rigidbody2D _rb;
        private Renderer _renderer;

        void Start()
        {
            AudioManager.instance.Play("PlayerRocket");

            _rb = GetComponent<Rigidbody2D>();
            _renderer = GetComponent<Renderer>();    
        }

        void FixedUpdate()
        {
            if (!_renderer.isVisible)
            {
                Destroy(gameObject);
            }
            _rb.AddForce(transform.up*moveSpeed, ForceMode2D.Impulse);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<Enemy>())
            {
                AudioManager.instance.Play("EnemyHit");

                var health = collision.gameObject.GetComponent<HealthManager>();
                health.DealDamage(damageValue);
                Destroy(gameObject);
            }
            else if (collision.gameObject.tag == "Obstacle")
            {
                Destroy(gameObject);
            }
        }
    }
}
