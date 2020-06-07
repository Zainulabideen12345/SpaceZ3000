using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEditor;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController _instance;
    private static int _killCount;
    private static int _currencyAmount;

    void Awake()
    {
        _instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyObjectsController.AllEnemiesDead)
        {
            UIController.ShowGameOverPanel(true);
        }
    }

    public static void OnGameOver()
    {
        UIController.ShowGameOverPanel(false);
    }

    public static void IncrementKillCount()
    {
        _killCount++;
    }

    public static int GetKillCount()
    {
        return _killCount;
    }

    public static void AddCurrency(int amount)
    {
        _currencyAmount += amount;
    }

    public static int GetCurrencyAmount()
    {
        return _currencyAmount;
    }
}
