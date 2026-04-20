using UnityEngine;

public class ResetCoinsScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(PlayerPrefs.HasKey("Total Coins"))
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("Reset Coins");
        }
    }
}
