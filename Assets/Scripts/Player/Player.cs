using DefaultNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text showCoinsAmount;
    private int coins=0;

    private void Start()
    {
        InvokeRepeating(nameof(DealZoneDamage), 0f, Zone.GetDamageInterval());
    }

    void Update()
    {
        showCoinsAmount.text = coins.ToString();
    }

    private void DealZoneDamage()
    {
        if (Zone.IsOutside(transform.position))
        {
            GetComponent<HealthManager>().DealFractionDamage(Zone.GetFractionDamage());
        }
    }

    public void AddCoins(int amountAdded)
    {
        coins += amountAdded;
    }
}
