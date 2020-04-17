using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private bool displayHealthBar = true;
        [SerializeField] private GameObject healthBarPrefab;
        
        private GameObject _healthBar;
        private Transform _bar;
        private const string BarName = "Bar";
        
        private void Update()
        {
            UpdateHealthBarPosition();
        }

        public void UpdateHealthBar(int currentHealth, int initialHealth)
        {
            if (!displayHealthBar) return;
            if (_healthBar == null)
            {
                CreateHealthBar();
            }
            _bar.localScale = new Vector3((float)currentHealth / initialHealth, 1f);
        }
        private void CreateHealthBar()
        {
            _healthBar = Instantiate(healthBarPrefab, GetComponent<Transform>(), true);
            _bar = _healthBar.transform.Find(BarName);
            UpdateHealthBarPosition();
        }

        private void UpdateHealthBarPosition()
        {
            if (!_healthBar) return;
            _healthBar.transform.position = new Vector3(transform.position.x, transform.position.y + 1f);
            _healthBar.transform.rotation = Quaternion.identity;
        }
    }
}