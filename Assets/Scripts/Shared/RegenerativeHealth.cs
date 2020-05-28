using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public class RegenerativeHealth : BaseHealth
    {
        public float LastTimeDamageTaken;
        private float regenerateCooldown;
        private int _regenerateAmount;
        public Guid Guid;

        public bool CanRegenerate() => (Time.time >= LastTimeDamageTaken + regenerateCooldown) && !IsFullHealth();

        public RegenerativeHealth(int initialHeath, Color healthBarColor, float regenerateCooldown, int regenerateAmount) : base(initialHeath, healthBarColor)
        {
            LastTimeDamageTaken = -100f;
            Guid = Guid.NewGuid();
            this.regenerateCooldown = regenerateCooldown;
            _regenerateAmount = regenerateAmount;
        }

        public IEnumerator RegenerateAmount()
        {
            while (!IsFullHealth())
            {
                AddHealth(_regenerateAmount);
                yield return new WaitForSeconds(.2f);
            }
        }

        public override int TakeDamage(int damage)
        {
            LastTimeDamageTaken = Time.time;
            return base.TakeDamage(damage);
        }

        public void AddHealthComponent(RegenerativeHealth newHealth)
        {
            base.AddHealthComponent(newHealth);
        }

        public override void UpdateShaderColor(Material material)
        {
            material.SetColor("_ShieldColor", healthBarColor);
        }
    }
}