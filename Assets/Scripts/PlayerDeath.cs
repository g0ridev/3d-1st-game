using UnityEngine;
using UnityEngine.SceneManagement;      // Needed for "Death"

public class PlayerDeath : MonoBehaviour
{
    public float fallDeathDistance = -15f;
    public GameObject DeathPanel;
    private bool isDead = false;
    private Rigidbody rb;

    public AudioClip deathSound;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
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
        GameManager.Instance.StopTimer();
        DeathPanel.SetActive(true);
        audioSource.PlayOneShot(deathSound);

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }


        // Deleting the game object results in camera display errors, so we can mimick
        // the instant respawn of small obstacle games using this
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
