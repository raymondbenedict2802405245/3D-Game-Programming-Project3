using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score = 0;
    public int bestScore = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;

    [Header("Timer Settings")]
    public float timeLimit = 60f; // misalnya 60 detik
    private float currentTime;

    [Header("UI")]
    public TextMeshProUGUI timerText; // UI untuk timer

    [Header("Panels")]
    public GameObject winPanel;
    public GameObject losePanel;

    void Awake()
    {
        instance = this;
        bestScore = PlayerPrefs.GetInt("BestScore", 0);

        scoreText.text = "Score: " + score;
        bestScoreText.text = "Best: " + bestScore;

        currentTime = timeLimit;
    }

    void Update()
    {
        // Countdown timer
        currentTime -= Time.deltaTime;
        if (currentTime < 0) currentTime = 0;

        // Update UI timer
        timerText.text = "Time: " + currentTime.ToString("F1");

        // Kalau waktu habis → cek hasil
        if (currentTime <= 0)
        {
            CheckResult();
        }
    }

    public void AddScore(int value)
    {
        score += value;
        scoreText.text = "Score: " + score;

        if (score > bestScore)
        {
            bestScore = score;
            bestScoreText.text = "Best: " + bestScore;
            PlayerPrefs.SetInt("BestScore", bestScore);
            PlayerPrefs.Save();
        }

        // Kalau sudah mencapai target sebelum waktu habis → langsung menang
        if (score >= 1500)
        {
            Win();
        }
    }

    void CheckResult()
    {
        if (score >= 1500)
        {
            Win();
        }
        else
        {
            Lose();
        }
    }

    void Win()
    {
        if (winPanel != null) winPanel.SetActive(true);
        Invoke("GoToMainMenu", 2f);
    }

    void Lose()
    {
        if (losePanel != null) losePanel.SetActive(true);
        Invoke("GoToMainMenu", 2f);
    }

    void GoToMainMenu()
    {
        SceneManager.LoadScene("proto");
    }
}
