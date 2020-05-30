using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text showCoinsAmount;
    private int coins=0;
    
    void Update()
    {
        showCoinsAmount.text = coins.ToString();
    }

    public void AddCoins(int amountAdded)
    {
        coins += amountAdded;
    }
}
