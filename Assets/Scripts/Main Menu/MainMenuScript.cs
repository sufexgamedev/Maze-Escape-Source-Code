using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject mainMenuScreen;
    public GameObject levelSelectionScreen;
    public GameObject creditsScreen;
    public GameObject bottomLeftText;
    public GameObject bottomRightText;

    public AudioSource audioSource;
    public AudioClip[] mainMenuSFX;

    private void Awake()
    {
        mainMenuScreen.SetActive(true);
        levelSelectionScreen.SetActive(false);
        creditsScreen.SetActive(false);
    }

    // Ui Buttons
    public void Play()
    {
        ClickSound();
        ShowLevelSelectionScreen();
    }

    public void ShowLevelSelectionScreen()
    {
        levelSelectionScreen.SetActive(true);
        mainMenuScreen.SetActive(false);
    }


    public void BackToMenu()
    {
        BackSound();
        ShowMainMenuScreen();
    }

    public void ShowMainMenuScreen()
    {
        mainMenuScreen.SetActive(true);
        levelSelectionScreen.SetActive(false);
        if (bottomLeftText.activeInHierarchy && bottomRightText.activeInHierarchy)
        {
            return;
        }
        else
        {
            creditsScreen.SetActive(false);
            bottomLeftText.SetActive(true);
            bottomRightText.SetActive(true);
        }
    }

    public void Credits()
    {
        ClickSound();
        ShowCreditsScreen();
    }
    public void ShowCreditsScreen()
    {
        creditsScreen.SetActive(true);
        mainMenuScreen.SetActive(false);
        levelSelectionScreen.SetActive(false);
        bottomLeftText.SetActive(false);
        bottomRightText.SetActive(false);
    }


    public void ExitGame()
    {
        ClickSound();
        Application.Quit();
    }


    // Levels (Scenes)
    public void Level1()
    {
        ClickSound();
        SceneManager.LoadScene(1);
    }
    public void Level2()
    {
        ClickSound();
        SceneManager.LoadScene(2);
    }
    public void Level3()
    {
        ClickSound();
        SceneManager.LoadScene(3);
    }
    public void Level4()
    {
        ClickSound();
        SceneManager.LoadScene(4);
    }
    public void Level5()
    {
        ClickSound();
        SceneManager.LoadScene(5);
    }
    public void Level6()
    {
        ClickSound();
        SceneManager.LoadScene(6);
    }
    public void Level7()
    {
        ClickSound();
        SceneManager.LoadScene(7);
    }
    public void Level8()
    {
        ClickSound();
        SceneManager.LoadScene(8);
    }
    public void Level9()
    {
        ClickSound();
        SceneManager.LoadScene(9);
    }


    // Sounds
    public void ClickSound()
    {
        audioSource.PlayOneShot(mainMenuSFX[0]);
    }

    public void BackSound()
    {
        audioSource.PlayOneShot(mainMenuSFX[1]);
    }

    public void HoverSound()
    {
        audioSource.PlayOneShot(mainMenuSFX[2]);
    }
}