using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;
    public AudioClip coinSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterStats stats = other.GetComponent<CharacterStats>();

            if (stats != null)
            {
                stats.AddCoin(value);
            }

            PlayCoinSound();
            Destroy(gameObject);
        }
    }
    private void PlayCoinSound()
    {
        if (coinSound != null)
        {
            AudioSource.PlayClipAtPoint(coinSound, transform.position);
        }
    }
}