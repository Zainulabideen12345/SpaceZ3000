using DefaultNamespace;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected int initialHealth = 200;
    [SerializeField] private bool displayHealthBar = true;
    [SerializeField] private GameObject healthBarPrefab;

    private int _currentHealth;
    private HealthBar _healthBar;

    void Start()
    {
        _currentHealth = initialHealth;
        _healthBar = GetComponent<HealthBar>();
    }
    

    public void DealDamage(int damage)
    {
        if (damage > _currentHealth || _currentHealth <= 0)
        {
            Die();
            return;
        }

        _currentHealth -= damage;

        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        if(!_healthBar) return;
        _healthBar.UpdateHealthBar(_currentHealth, initialHealth);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
    
}
