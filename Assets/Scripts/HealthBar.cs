using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(ShieldHealth))]
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private bool displayHealthBar = true;
        [SerializeField] private GameObject healthBarPrefab;
        
        private GameObject _healthBar;
        private Transform _bar;
        private SpriteRenderer _currentHealthSprite;
        private const string BarName = "Bar";
        
        private void Update()
        {
            UpdateHealthBarPosition();
        }

        // public void UpdateHealthBar(int currentHealth, int initialHealth)
        // {
        //     if (!displayHealthBar) return;
        //     if (_healthBar == null)
        //     {
        //         CreateHealthBar();
        //     }
        //     _bar.localScale = new Vector3((float)currentHealth / initialHealth, 1f);
        // }
        public void UpdateHealthBar(List<BaseHealth> healths)
        {
            if (!displayHealthBar) return;
            if (_healthBar == null)
            {
                CreateHealthBar(healths.Count());
            }
            var initialHealth = healths.Sum(h => h.initialHeath);
            var currentHealth = healths.Sum(h => h.currentHealth);
            UpdateGradient(healths, currentHealth);
            _bar.localScale = new Vector3((float)currentHealth / initialHealth, 1f);
        }
        private void CreateHealthBar(int healths)
        {
            _healthBar = Instantiate(healthBarPrefab, GetComponent<Transform>(), true);
            _bar = _healthBar.transform.Find(BarName);
            _currentHealthSprite = _bar.transform.Find("BarSprite").GetComponent<SpriteRenderer>();
            UpdateHealthBarPosition();
        }

        private void UpdateGradient(List<BaseHealth> healths, int totalHealth)
        {
            var healthPercentage = 0f;
            for (int i = healths.Count - 1; i >= 0; i--)
            {
                var health = healths[i];
                healthPercentage += (float) health.currentHealth / totalHealth;
                if (i == healths.Count - 1)
                {
                    _currentHealthSprite.material.SetFloat("_Scale", healthPercentage); 
                }
            }
        }

        private void UpdateHealthBarPosition()
        {
            if (!_healthBar) return;
            _healthBar.transform.position = new Vector3(transform.position.x, transform.position.y + 1f);
            _healthBar.transform.rotation = Quaternion.identity;
        }
    }
}