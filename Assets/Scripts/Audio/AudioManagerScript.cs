using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManagerScript : MonoBehaviour
{
    public static AudioManagerScript instance;

    public AudioClip[] gameSFX;
    public AudioClip[] uiSFX;
    public AudioSource backgroundmusicAS;
    public AudioSource sFXAudioSource;

    private void Awake()
    {
        // used for singleton (for this script accessing globaly)
        if (instance == null)
        {
            instance = this;
        }
    }


    // Game Sound (SFX)
    public void CoinPickupSound()
    {
        sFXAudioSource.PlayOneShot(gameSFX[0]);
    }

    public void KeyPickupSound()
    {
        sFXAudioSource.PlayOneShot(gameSFX[1]);
    }

    public void LevelCompleteSound()
    {
        sFXAudioSource.PlayOneShot(gameSFX[2]);
        backgroundmusicAS.Stop();
    }

    //UI Sound (SFX)
    public void HoverSound()
    {
        sFXAudioSource.PlayOneShot(uiSFX[0]);
    }

    public void ClickSound()
    {
        sFXAudioSource.PlayOneShot(uiSFX[1]);
    }

    public void BackSound()
    {
        sFXAudioSource.PlayOneShot(uiSFX[2]);
    }
}
