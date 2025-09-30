using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public int score = 0;
    public TextMeshProUGUI scoreDisplay;  // In-game score display
    public int greenEnemyKills = 0; // Used to track green enemies killed so that red enemies can spawn after every 5 kills

    private void Awake()
    {
        // Singleton pattern to ensure only one ScoreManager exists.
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;

        }
    }

    // This method adds to the total score count
    public void AddScore(int points)
    {
        score += points;
        if (scoreDisplay != null)
        {
            scoreDisplay.text = "Score: " + score;
        }
        Debug.Log("Score updated: " + score);
    }
}
