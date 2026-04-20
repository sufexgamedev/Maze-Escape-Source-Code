using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public PlayerMovementScript playerMovementScript;

    private void Awake()
    {
        // used for enabling playermovemnts when the scene reloads
        playerMovementScript.playerInput.Enable();
    }
    
    // Update is called once per frame
    void Update()
    {
        // used for detecting if these panels are active/not active, disable/enable player movements
        if(UIManagerScript.instence.levelCompleteScreen.activeInHierarchy || UIManagerScript.instence.pauseMenuScreen.activeInHierarchy)
        {
            playerMovementScript.playerInput.Disable();
        }
        else
        {
            playerMovementScript.playerInput.Enable();
        }
    }


    // Scene buttons
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        AudioManagerScript.instance.ClickSound();
    }

    public void RestaartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
