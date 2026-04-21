using UnityEngine;
using TMPro;

public class course_completion : MonoBehaviour
{
    public GameObject winPanel;

    public TMP_Text finalTimeText;
    public TMP_Text finalCoinsText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.StopTimer();
            }

            if (winPanel != null)
            {
                winPanel.SetActive(true);
            }

            Rigidbody rb = other.GetComponent<Rigidbody>();

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

            CharacterStats stats = other.GetComponent<CharacterStats>();
            if (finalCoinsText != null && stats != null)
            {
                finalCoinsText.text = "Coins: " + stats.coins;
            }

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Time.timeScale = 0f;
        }
    }
}