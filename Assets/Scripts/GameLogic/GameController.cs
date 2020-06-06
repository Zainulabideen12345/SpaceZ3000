using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEditor;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController _instance;

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
}
