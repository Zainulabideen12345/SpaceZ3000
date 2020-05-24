using DefaultNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealDrop : MonoBehaviour
{
    [SerializeField] private int healValue = 1000;
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.GetComponent<Player>() != null)
        {
            var health = hitInfo.gameObject.GetComponent<HealthManager>();
            health?.AddHealthAmount(healValue);
            Destroy(gameObject);
        }
    }
}
