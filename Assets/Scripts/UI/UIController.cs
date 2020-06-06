using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private static UIController _instance;

    public GameObject killCounter;
    public GameObject coinsCounter;
    public GameObject minimap;
    public GameObject energyBar;
    public GameObject gameOverPanel;
    public TextMeshProUGUI GameOverText;

    void Awake()
    {
        _instance = this;
    }

    public static void ShowGameOverPanel(bool win)
    {
        _instance.killCounter.SetActive(false);
        _instance.coinsCounter.SetActive(false);
        _instance.minimap.SetActive(false);
        _instance.energyBar.SetActive(false);

        _instance.GameOverText.text = win ? "You won!" : "You sook!";
        _instance.gameOverPanel.SetActive(true);
    }

    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnExitToMenuButtonClick()
    {
        SceneManager.LoadScene("Menu");
    }
}
