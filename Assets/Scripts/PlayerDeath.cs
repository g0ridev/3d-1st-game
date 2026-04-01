using UnityEngine;
using UnityEngine.SceneManagement;      // Needed for "Death"

public class PlayerDeath : MonoBehaviour
{
    public float fallDeathDistance = -15f;
    private bool isDead = false;

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


        // Deleting the game object results in camera display errors, so we can mimick
        // the instant respawn of small obstacle games using this
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
