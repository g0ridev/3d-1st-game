using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TextMeshProUGUI timerText;

    private float timer = 0f;
    private bool isRunning = false;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        isRunning = true;
    }

    void Update()
    {
        if (!isRunning) return;
        timer += Time.deltaTime;
        int minutes = (int)(timer / 60);
        int seconds = (int)(timer % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public float GetTime() { return timer; }
}