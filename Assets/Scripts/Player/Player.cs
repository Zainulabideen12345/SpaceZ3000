using DefaultNamespace;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Energy")]
    [SerializeField] private int initialEnergy = 300;
    [SerializeField] private int maxEnergy = 500;
    private int _currentEnergy;

    private void Start()
    {
        if (Zone.Exists)
        {
            InvokeRepeating(nameof(DealZoneDamage), 0f, Zone.GetDamageInterval());
        }

        _currentEnergy = initialEnergy;
    }
   
    private void DealZoneDamage()
    {
        if (Zone.Exists && Zone.IsOutside(transform.position))
        {
            GetComponent<HealthManager>().DealFractionDamage(Zone.GetFractionDamage());
        }
    }

    private void OnDestroy()
    {
        GameController.OnGameOver();
    }

    public void AddEnergy(int amount)
    {
        _currentEnergy += amount;
        if (_currentEnergy > maxEnergy)
        {
            _currentEnergy = maxEnergy;
        }
    }
    public void SpendEnergy(int amount)
    {
        _currentEnergy -= amount;
    }

    public int GetCurrentEnergy()
    {
        return _currentEnergy;
    }

    public float GetCurrentEnergyPercentage()
    {
        return (float) _currentEnergy / maxEnergy;
    }
}
