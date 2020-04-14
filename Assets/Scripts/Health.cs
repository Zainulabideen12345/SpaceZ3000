using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int initialHealth = 200;
    [SerializeField] private bool displayHealthBar = true;
    [SerializeField] private GameObject healthBarPrefab;

    private int _currentHealth;
    private GameObject _healthBar;

    void Start()
    {
        _currentHealth = initialHealth;
    }

    private void FixedUpdate()
    {
        UpdateHealthBarPosition();
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

    private void Die()
    {
        Destroy(gameObject);
    }

   
    private void UpdateHealthBar()
    {
        if (displayHealthBar)
        {
            if (_healthBar == null)
            {
                CreateHealthBar();
            }

            _healthBar.transform.Find("Bar").localScale = new Vector3((float)_currentHealth / initialHealth, 1f);
        }

    }
    private void CreateHealthBar()
    {
        _healthBar = Instantiate(healthBarPrefab) as GameObject;
        _healthBar.transform.SetParent(GetComponent<Transform>());
        UpdateHealthBarPosition();
    }

    private void UpdateHealthBarPosition()
    {
        if (_healthBar != null)
        {
            _healthBar.transform.position = new Vector3(transform.position.x, transform.position.y + 1f);
            _healthBar.transform.rotation = Quaternion.identity;
        }
    }
}
