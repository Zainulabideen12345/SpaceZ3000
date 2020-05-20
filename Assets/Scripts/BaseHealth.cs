using System;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public class BaseHealth
    {
        private int _initialHeath;
        protected Color _healthBarColor = Color.green;
        private int _currentHealth;

        public int currentHealth => _currentHealth;
        public int initialHeath => _initialHeath;
        public Color healthBarColor => _healthBarColor;


        public event EventHandler HealthAdded;

        public BaseHealth(int initialHeath, Color healthBarColor)
        {
            _initialHeath = initialHeath;
            _currentHealth = initialHeath;
            _healthBarColor = healthBarColor;
        }

        public bool IsHealthDepleted() => _currentHealth <= 0;
        public bool IsFullHealth() => _initialHeath == _currentHealth;

        public virtual int TakeDamage(int damage)
        {
            if (_currentHealth > damage)
            {
                _currentHealth -= damage;
                return 0;
            }
            var damageLeftover = damage - _currentHealth;
            _currentHealth = 0;
            return damageLeftover;
        }

        public void AddHealthComponent(BaseHealth newHealth)
        {
            _initialHeath += newHealth._initialHeath;
            _currentHealth += newHealth._initialHeath;
            HealthAdded?.Invoke(this, EventArgs.Empty);
        }

        public void RemoveHealthComponent(BaseHealth health)
        {
            _initialHeath -= health._initialHeath;
            _currentHealth = (currentHealth - health._initialHeath > 0)
                ? currentHealth - health._initialHeath
                : _currentHealth;
            HealthAdded?.Invoke(this, EventArgs.Empty);
        }

        public void AddHealth(int health)
        {
            if(IsFullHealth()) return;
            
            _currentHealth = currentHealth + health >= _initialHeath ? _initialHeath : _currentHealth + health;
            HealthAdded?.Invoke(this, EventArgs.Empty);
        }

        public virtual void UpdateShaderColor(Material material)
        {
            material.SetColor("_HealthColor", healthBarColor);
        }
    }
}