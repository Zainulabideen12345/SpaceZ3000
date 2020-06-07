using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private static UIController _instance;

    private Player _player;

    public GameObject killStatsPanel;
    public GameObject currencyPanel;
    public GameObject minimap;
    public GameObject energyBar;
    public GameObject gameOverPanel;

    public TextMeshProUGUI killCountText;
    public TextMeshProUGUI currencyAmountText;
    public TextMeshProUGUI gameOverText;
    public GameObject energyBarLevel;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        _player = GameObject.Find("Player")?.GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        if (!gameOverPanel.activeInHierarchy)
        {
            killCountText.text = GameController.GetKillCount().ToString();
            currencyAmountText.text = GameController.GetCurrencyAmount().ToString();

            if (_player != null)
            {
                energyBarLevel.transform.localScale = new Vector3(_player.GetCurrentEnergyPercentage(), 1f, 1f);
            }
        }
    }

    public static void ShowGameOverPanel(bool win)
    {
        _instance.killStatsPanel.SetActive(false);
        _instance.currencyPanel.SetActive(false);
        _instance.minimap.SetActive(false);
        _instance.energyBar.SetActive(false);

        _instance.gameOverText.text = win ? "You won!" : "You sook!";
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
