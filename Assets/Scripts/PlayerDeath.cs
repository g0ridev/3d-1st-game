using UnityEngine;
using TMPro;

public class PlayerDeath : MonoBehaviour
{
    public float fallDeathDistance = -15f;
    public GameObject DeathPanel;

    public TMP_Text finalTimeText;
    public TMP_Text finalCoinsText;

    private bool isDead = false;
    private Rigidbody rb;

    public AudioClip deathSound;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

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

        // Stop timer
        if (GameManager.Instance != null)
        {
            GameManager.Instance.StopTimer();
        }

        // Show panel
        if (DeathPanel != null)
        {
            DeathPanel.SetActive(true);
        }

        // Play sound
        if (audioSource != null && deathSound != null)
        {
            audioSource.PlayOneShot(deathSound);
        }

        // Freeze player
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }

        // ===== FINAL TIME =====
        if (finalTimeText != null && GameManager.Instance != null)
        {
            float time = GameManager.Instance.GetTime();
            int minutes = (int)(time / 60);
            int seconds = (int)(time % 60);

            finalTimeText.text = "Time: " + minutes.ToString("00") + ":" + seconds.ToString("00");
        }

        // ===== FINAL COINS =====
        CharacterStats stats = GetComponent<CharacterStats>();
        if (finalCoinsText != null && stats != null)
        {
            finalCoinsText.text = "Coins: " + stats.coins;
        }

        // Unlock mouse + pause
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;
    }
}