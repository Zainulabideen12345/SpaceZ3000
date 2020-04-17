using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class RegenerativeHealth : BaseHealth
    {
        public float LastTimeDamageTaken;
        private float regenerateCooldown;
        private int _regenerateAmount;
        public Guid Guid;

        public bool CanRegenerate() => (Time.time >= LastTimeDamageTaken + regenerateCooldown) && !IsFullHealth();

        public RegenerativeHealth(int initialHeath, float regenerateCooldown, int regenerateAmount) : base(initialHeath)
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
    }
}