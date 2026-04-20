using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerScript : MonoBehaviour
{
    public static UIManagerScript instence;
    public CoinCollectorScript coinCollectorScript;

    public GameObject levelCompleteScreen;
    public GameObject pauseMenuScreen;
    public TextMeshProUGUI coinsCollectedText;
    public TextMeshProUGUI totalCoinsText;
    public TextMeshProUGUI levelNumText;
    public TextMeshProUGUI totalCoinsCollectedText;
    public GameObject PauseButton;


    private void Awake()
    {
        // used for singleton (for this script accessing globaly)
        instence = this;
        // used for disabling UI GameObjects when the scene loads
        levelCompleteScreen.SetActive(false);
        pauseMenuScreen.SetActive(false);
        // updating the pause menu level number text whem the scene starts
        UpdateLevelNumText();

        UpdateTotalCoinsCollectedText();
    }

    // used for Showing Pause Menu Screen
    public void ShowPauseScreen()
    {
        pauseMenuScreen.SetActive(true);
        PauseButton.SetActive(false);
        AudioManagerScript.instance.ClickSound();
        AudioManagerScript.instance.backgroundmusicAS.Pause();
    }

    // used for Hiding Pause Menu Screen
    public void HidePauseScreen()
    {
        pauseMenuScreen.SetActive(false);
        PauseButton.SetActive(true);
        AudioManagerScript.instance.BackSound();
        AudioManagerScript.instance.backgroundmusicAS.UnPause();
    }


    // used for Showing Win Screen
    public void ShowLevelCompleteScreen()
    {
        levelCompleteScreen.SetActive(true);
        PauseButton.SetActive(false);
        ShowCoins();
        AudioManagerScript.instance.LevelCompleteSound();
    }


    // used for Showing coin texts
    public void ShowCoins()
    {
        coinsCollectedText.text += coinCollectorScript.CoinsCollected().ToString();
        totalCoinsText.text += coinCollectorScript.TotalCoins().ToString();
    }

    // used for detecting currunt level number as text
    public void UpdateLevelNumText()
    {
        int level = SceneManager.GetActiveScene().buildIndex;
        levelNumText.text += level;
    }

    // used for loading your currunt total coins collected and showing as text on pause menu
    public void UpdateTotalCoinsCollectedText()
    {
        totalCoinsCollectedText.text += coinCollectorScript.TotalCoins();
    }
}
