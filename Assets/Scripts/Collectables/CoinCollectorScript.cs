using UnityEngine;

public class CoinCollectorScript : MonoBehaviour
{
    private int coinsCollected = 0;
    private int totalCoins = 0;


    private void Awake()
    {
        // loads currunt total coins
        totalCoins = PlayerPrefs.GetInt("Total Coins", 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // used for detecting coin using Tag
        if (collision.gameObject.CompareTag("Coin"))
        {
            coinsCollected++;
            Destroy(collision.gameObject);
            AudioManagerScript.instance.CoinPickupSound();
            Debug.Log("Coins: " + coinsCollected);
        }

        // used for detecting Finish Marker Tag and sum all the coins to another variable (total coins)
        if(collision.gameObject.CompareTag("Finish Marker"))
        {
            totalCoins += coinsCollected;
            // saviing currunt total coins
            PlayerPrefs.SetInt("Total Coins", totalCoins);
        }
    }

    // used for using these variables on UIManagerScript (or any another script) with the help of public methods because these variables are private
    public int CoinsCollected()
    {
        return coinsCollected;
    }

    public int TotalCoins()
    {
        totalCoins = PlayerPrefs.GetInt("Total Coins", 0);
        return totalCoins;
    }

}   
