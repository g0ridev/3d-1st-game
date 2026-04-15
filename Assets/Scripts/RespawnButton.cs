using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnButton : MonoBehaviour
{
    public void RespawnLevel()
    {
        Time.timeScale = 1f; //unpause the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
