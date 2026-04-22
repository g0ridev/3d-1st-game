using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public TMP_Text coinText;
    public TMP_Text timerText;
    public TMP_Text lifeText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: 0";
        }

        if (timerText != null)
        {
            timerText.text = "Time: 0.0";
        }

        if (lifeText != null)
        {
            lifeText.text = "Lives: 1";
        }
    }

    public void UpdateCoinText(int coins)
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + coins;
        }
    }

    public void UpdateTimerText(float time)
    {
        if (timerText != null)
        {
            timerText.text = "Time: " + time.ToString("F1");
        }
    }

    public void UpdateLifeText(int life)
    {
        if (lifeText != null)
        {
            lifeText.text = "Lives: " + life;
        }
    }
}