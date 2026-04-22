using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [Header("Stats")]
    public int coins = 0;
    public int life = 1;

    private int nextLifeAt = 10;

    private void Start()
    {
        UpdateUI();
    }

    public void AddCoin(int amount)
    {
        coins += amount;
        Debug.Log("Coins: " + coins);

        CheckForLifeGain();
        UpdateUI();
    }

    private void CheckForLifeGain()
    {
        while (coins >= nextLifeAt)
        {
            life++;
            Debug.Log("Life gained! Lives: " + life);
            nextLifeAt += 10;
        }
    }

    public bool HasExtraLife()
    {
        return life > 1;
    }

    public void LoseLife()
    {
        if (life > 1)
        {
            life--;
            Debug.Log("Life used! Lives left: " + life);
            UpdateUI();
        }
    }

    public void UpdateUI()
    {
        if (UIManager.instance != null)
        {
            UIManager.instance.UpdateCoinText(coins);
            UIManager.instance.UpdateLifeText(life);
        }
    }
}