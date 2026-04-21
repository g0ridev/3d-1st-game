using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public void GoToTitle()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("TitleScreen");
    }
}