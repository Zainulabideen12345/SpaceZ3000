using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class EnemyHealer : MonoBehaviour
    {
        private Coroutine _coroutine;
        [SerializeField] private bool canHeal = true;
        private void Start()
        {
            _coroutine = StartCoroutine(RestoreHealth());
        }

        private IEnumerator RestoreHealth()
        {
            while (canHeal)
            {
                var enemies = GameObject.FindGameObjectsWithTag("Enemy");

                foreach (var enemy in enemies)
                {
                    if (Vector2.Distance(enemy.transform.position, transform.position) <= 10)
                    {
                        enemy.GetComponent<HealthManager>()?.AddHealthAmount(20);
                    }
                }
            
                yield return new WaitForSeconds(1);
            }
        }

        private void OnDestroy()
        {
            StopCoroutine(_coroutine);
        }
    }
}