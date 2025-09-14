using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int lives = 3;
    public int score = 0;

    public int lastLevelBuildIndex = 2; // até Level_2
    public string victoryScene = "Victory";
    public string defeatScene = "Defeat";

    private Text scoreText;
    private Text livesText;

    private void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else { Destroy(gameObject); return; }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene s, LoadSceneMode m)
    {
        var st = GameObject.Find("ScoreText");
        if (st) scoreText = st.GetComponent<Text>();
        var lt = GameObject.Find("LivesText");
        if (lt) livesText = lt.GetComponent<Text>();
        UpdateUI();
    }

    public void AddScore(int v) { score += v; UpdateUI(); }
    public void LoseLife()
    {
        lives--; UpdateUI();
        if (lives <= 0) SceneManager.LoadScene(defeatScene);
    }

    public void BrickDestroyed()
    {
        if (GameObject.FindGameObjectsWithTag("Brick").Length <= 0)
        {
            int next = SceneManager.GetActiveScene().buildIndex + 1;
            if (next <= lastLevelBuildIndex) SceneManager.LoadScene(next);
            else SceneManager.LoadScene(victoryScene);
        }
    }

    void UpdateUI()
    {
        if (scoreText) scoreText.text = "Score: " + score;
        if (livesText) livesText.text = "Lives: " + lives;
    }

    public void ResetGame()
    {
        score = 0; lives = 3; UpdateUI();
    }
}
