using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreenManager : MonoBehaviour
{
    public string gameSceneName = "Level01";

    void Start()
    {
        Button startButton = GameObject.Find("StartButton").GetComponent<Button>();
        startButton.onClick.AddListener(OnStartClicked);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            OnStartClicked();
    }

    void OnStartClicked()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}