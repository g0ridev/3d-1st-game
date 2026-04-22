using UnityEngine;
using TMPro;

public class PlayerDeath : MonoBehaviour
{
    public float fallDeathDistance = -15f;
    public GameObject DeathPanel;

    public TMP_Text finalTimeText;
    public TMP_Text finalCoinsText;

    public Transform respawnPoint;

    private bool isDead = false;
    private Rigidbody rb;
    private CharacterStats stats;

    public AudioClip deathSound;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        stats = GetComponent<CharacterStats>();

        if (DeathPanel != null)
        {
            DeathPanel.SetActive(false);
        }
    }

    void Update()
    {
        if (!isDead && transform.position.y < fallDeathDistance)
        {
            Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isDead && collision.gameObject.CompareTag("Obstacle"))
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;

        // Play sound
        if (audioSource != null && deathSound != null)
        {
            audioSource.PlayOneShot(deathSound);
        }

        // If player has an extra life, use it and respawn
        if (stats != null && stats.HasExtraLife())
        {
            stats.LoseLife();
            Respawn();
            return;
        }

        // Otherwise: game over
        if (GameManager.Instance != null)
        {
            GameManager.Instance.StopTimer();
        }

        if (DeathPanel != null)
        {
            DeathPanel.SetActive(true);
        }

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }

        if (finalTimeText != null && GameManager.Instance != null)
        {
            float time = GameManager.Instance.GetTime();
            int minutes = (int)(time / 60);
            int seconds = (int)(time % 60);

            finalTimeText.text = "Time: " + minutes.ToString("00") + ":" + seconds.ToString("00");
        }

        if (finalCoinsText != null && stats != null)
        {
            finalCoinsText.text = "Coins: " + stats.coins;
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;
    }

    private void Respawn()
    {
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }

        if (respawnPoint != null)
        {
            transform.position = respawnPoint.position;
        }
        else
        {
            Debug.LogWarning("Respawn point not assigned!");
        }

        isDead = false;
    }
}