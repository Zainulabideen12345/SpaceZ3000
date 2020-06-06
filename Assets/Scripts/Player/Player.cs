using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text showCoinsAmount;
    public Text showKillsAmount;
    private int _coins;
    private int _kills;
    private static int kills = 0;

    private void Start()
    {
        if (Zone.Exists)
        {
            InvokeRepeating(nameof(DealZoneDamage), 0f, Zone.GetDamageInterval());
        }
    }
   
    private void DealZoneDamage()
    {
        if (Zone.Exists && Zone.IsOutside(transform.position))
        {
            GetComponent<HealthManager>().DealFractionDamage(Zone.GetFractionDamage());
        }
    }

    public void AddCoins(int amountAdded)
    {
        _coins += amountAdded;
        showCoinsAmount.text = _coins.ToString();
    }

    public void AddKills()
    {
        _kills++;
        showKillsAmount.text = _kills.ToString();
    }
}
