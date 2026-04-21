using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [Header("Stats")]
    public int coins = 0;

    private void Start()
    {
        UpdateUI();
    }

    public void AddCoin(int amount)
    {
        coins += amount;
        Debug.Log("Coins: " + coins);
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (UIManager.instance != null)
        {
            UIManager.instance.UpdateCoinText(coins);
        }
    }
}