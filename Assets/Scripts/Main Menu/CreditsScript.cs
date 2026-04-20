using TMPro;
using UnityEngine;

public class CreditsScript : MonoBehaviour
{
    public TextMeshProUGUI creditsText;
    private readonly float speed = 100;
    private Vector2 posTop;
    private Vector2 posBottom;
    private bool isEnabled = false;

    private void Awake()
    {
        // currunt Position
        posTop = creditsText.rectTransform.offsetMax;
        posBottom = -creditsText.rectTransform.offsetMin;
    }

    // Update is called once per frame
    void Update()
    {
        // Text Scroll when active
        creditsText.transform.Translate(speed * Time.deltaTime * Vector2.up);
    }

    private void OnEnable()
    {
        isEnabled = true;
    }

    private void OnDisable()
    {
        if (isEnabled)
        {
            creditsText.rectTransform.offsetMax = posTop;
            creditsText.rectTransform.offsetMin = -posBottom;
        }
    }
}
