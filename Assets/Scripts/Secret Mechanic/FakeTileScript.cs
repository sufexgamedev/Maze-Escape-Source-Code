using UnityEngine;

public class FakeTileScript : MonoBehaviour
{
    public CoinCollectorScript coinCollectorScript;

    public SpriteRenderer fakeTile;

    private bool secretUnlocked = false;

    // used for detecting if 80 coins collected, then unlock the secret area
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(coinCollectorScript.CoinsCollected() == 80)
        {
            secretUnlocked = true;

            if (collision.gameObject.CompareTag("Fake Tile") && secretUnlocked)
            {
                BoxCollider2D bc = fakeTile.GetComponent<BoxCollider2D>();

                bc.isTrigger = true;

                Color col = fakeTile.color;

                col.a = 0.2f;

                fakeTile.color = col;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (secretUnlocked)
        {
            BoxCollider2D bc = fakeTile.GetComponent<BoxCollider2D>();

            bc.isTrigger = true;

            Color col = fakeTile.color;

            col.a = 1;

            fakeTile.color = col;
        }
    }
}
