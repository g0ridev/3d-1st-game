using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterStats stats = other.GetComponent<CharacterStats>();

            if (stats != null)
            {
                stats.AddCoin(value);
            }

            Destroy(gameObject);
        }
    }
}