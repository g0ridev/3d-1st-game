using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections; // Needed for screen delay

public class TitleScreenManager : MonoBehaviour
{
    public string gameSceneName = "Level01";
    public AudioClip gameStart;

    void Start()
    {
        Button startButton = GameObject.Find("StartButton").GetComponent<Button>();
        startButton.onClick.AddListener(OnStartClicked);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            OnStartClicked();
        }
    }

    void OnStartClicked()
    {
        StartCoroutine(playGameSound());
    }

    IEnumerator playGameSound()
    {
        // This allows th sound to actually have time to play
        if (gameStart != null)
        {
            AudioSource.PlayClipAtPoint(gameStart, transform.position);
            yield return new WaitForSeconds(gameStart.length);
        }
        SceneManager.LoadScene(gameSceneName);
    }
}