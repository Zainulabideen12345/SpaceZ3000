using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class EnemyHealthAdder : MonoBehaviour
    {
        [SerializeField] private BaseHealthConfig healthConfig;
        private readonly List<HealthManager> _enemyHealths = new List<HealthManager>();

        private void OnTriggerEnter2D(Collider2D other)
        { 
            var healthManager =  other.gameObject.GetComponent<HealthManager>();
            if(_enemyHealths.Contains(healthManager)) return;
            _enemyHealths.Add(healthManager);
           healthManager?.AddHealthComponent(healthConfig);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            var healthManager =  other.gameObject.GetComponent<HealthManager>();
            _enemyHealths.Remove(healthManager);
            healthManager?.RemoveHealthComponent(healthConfig);
        }

        private void OnDestroy()
        {
            foreach (var healthManager in _enemyHealths)
            {
                healthManager?.RemoveHealthComponent(healthConfig);
            }
        }
    }
}