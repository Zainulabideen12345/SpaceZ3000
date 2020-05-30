﻿using DefaultNamespace;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private int damageValue;

    private Rigidbody2D _rb;
    private Renderer _renderer;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<Renderer>();

        AudioManager.instance.Play("Pew");
    }

    void Update()
    {
        if (!_renderer.isVisible)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            AudioManager.instance.Play("PlayerHit");

            var health = collision.gameObject.GetComponent<HealthManager>();
            health.DealDamage(damageValue);
        }
        else if (collision.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }
}
