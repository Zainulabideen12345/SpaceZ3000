using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace DefaultNamespace
{
    public class HealthManager : MonoBehaviour
    {
        [SerializeField] private List<BaseHealthConfig> healthConfigs;
        
        private HealthBar _healthBar;
        private List<BaseHealth> _healths;
        private Dictionary<Guid, Coroutine> _regenerations;

        private void Start()
        {
            _healthBar = GetComponent<HealthBar>();
            InitializeHealthList();
            _healths.ForEach(h => h.HealthAdded += OnHealthAdded);
            _regenerations = new Dictionary<Guid, Coroutine>();
        }

        private void Update()
        {
            Regenerate();
        }

        private void InitializeHealthList()
        {
            _healths = healthConfigs.Select(healthConfig => healthConfig.CreateHealth()).ToList();
        }

        public void AddHealthAmount(int health)
        {
            if(_healths != null &&  _healths.Count > 0 && _healths.TrueForAll(h => h.IsFullHealth())) return;
            
            var damagedHealth = _healths?.FindLast(h => !h.IsFullHealth());
            damagedHealth?.AddHealth(health);
        }

        public void DealDamage(int damage)
        {
            if(HasShield()) return;
            
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
            _healthBar.UpdateHealthBar(_healths);
        }

        private void Die()
        {
            Destroy(gameObject);
        }
        
        public bool HasShield()
        {
            foreach (Transform child in transform)
            {
                if (child.CompareTag("Shield"))
                {
                    return true;
                }
            }

            return false;
        }
    }
}