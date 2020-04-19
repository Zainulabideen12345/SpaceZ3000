using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    public class ShieldHealth : MonoBehaviour
    {
        [Header("HealthAmount")]
        [SerializeField] private int initialBaseHealth = 200;
        [SerializeField] private int initialShieldHealth = 50;
        

        [Header("Regeneration")] 
        [SerializeField] private float regenerateCooldown = 1f;
        [SerializeField] private int regenerateAmount = 1;
        
        [SerializeField] private bool displayHealthBar = true;
        [SerializeField] private GameObject healthBarPrefab;

        private int _currentHealth;
        private HealthBar _healthBar;
        public List<BaseHealth> _healths;
        private Dictionary<Guid, Coroutine> _regenerations;

        private void Start()
        {
            _currentHealth = initialBaseHealth;
            _healthBar = GetComponent<HealthBar>();
            _healths = new List<BaseHealth>
            {
                new RegenerativeHealth(initialShieldHealth, regenerateCooldown, regenerateAmount),
                new BaseHealth(initialBaseHealth)
            };
            _healths.ForEach(h => h.HealthAdded += OnHealthAdded);
            _regenerations = new Dictionary<Guid, Coroutine>();
        }

        private void Update()
        {
            Regenerate();
        }

        public void DealDamage(int damage)
        {
            if (damage > _healths.Sum(h => h.currentHealth) || _healths.TrueForAll(h => h.IsHealthDepleted()))
            {
                Die();
                return;
            }
            StopRegenerate();
            TakeDamage(damage);
            
            UpdateHealthBar();
        }

        private void TakeDamage(int damage)
        {
            while (damage > 0)
            {
                var activeHealth = _healths.Find(h => !h.IsHealthDepleted());
                var damageLeft = activeHealth.TakeDamage(damage);
                if (damageLeft > 0)
                {
                    damage -= damageLeft;
                }
                else
                {
                    damage = 0;
                }
            }
        }

        private void Regenerate()
        {
            foreach (var baseHealth in _healths.Where(h => h.GetType() == typeof(RegenerativeHealth)))
            {
                var health = (RegenerativeHealth) baseHealth;
                if (health.CanRegenerate() && !_regenerations.ContainsKey(health.Guid))
                {
                    _regenerations.Add(health.Guid ,StartCoroutine(health.RegenerateAmount()));
                }
            }
        }

        private void StopRegenerate()
        {
            foreach (var regeneration in _regenerations)
            {
                StopCoroutine(regeneration.Value);   
            }
            _regenerations = new Dictionary<Guid, Coroutine>();
        }

        private void OnHealthAdded(object sender, EventArgs e)
        {
            UpdateHealthBar();
        }

        private void UpdateHealthBar()
        {
            if(!_healthBar) return;
            // _healthBar.UpdateHealthBar(_currentHealth, initialBaseHealth);
            _healthBar.UpdateHealthBar(_healths);
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}