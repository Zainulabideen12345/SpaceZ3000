using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int initialHealth = 200;
    private int _currentHealth;
    void Start()
    {
        _currentHealth = initialHealth;
    }

    public void DealDamage(int damage)
    {
        if (damage > _currentHealth || _currentHealth <= 0)
        {
            Die();
            return;
        }

        _currentHealth -= damage;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
