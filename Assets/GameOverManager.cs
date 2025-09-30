using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager Instance { get; private set; }

    [Header("UI Elements")]
    public GameObject gameOverPanel;      
    public TextMeshProUGUI gameOverLabel;   // UI element for "Game Over" text
    public TextMeshProUGUI scoreLabel;      // UI element that displays the final score

    private void Awake()
    {
        // Singleton pattern for the GameOverManager.
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        // Ensure the Game Over panel starts off hidden.
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
            Debug.Log("GameOverPanel disabled in Awake");
        }
        else
        {
            Debug.LogWarning("GameOverPanel reference is missing!");
        }
    }

    // Method is called when a player looses all of their health
    public void GameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            Debug.Log("GameOverPanel activated.");
        }
        else
        {
            Debug.LogWarning("GameOverPanel reference is missing!");
        }

        // Update the final score using the ScoreManager.
        if (ScoreManager.Instance != null)
        {
            Debug.Log("Final Score from ScoreManager: " + ScoreManager.Instance.score);
            if (scoreLabel != null)
            {
                scoreLabel.text = "Score: " + ScoreManager.Instance.score;
                Debug.Log("GameOver scoreLabel updated: " + scoreLabel.text);
            }
            else
            {
                Debug.LogWarning("scoreLabel reference is missing!");
            }
        }
        else
        {
            Debug.LogWarning("ScoreManager instance is null!");
        }

        // Pause the game.
        Time.timeScale = 0f;
    }

    //Called by the restart button on the game over screen
    public void RestartGame()
    {
        // Resume normal game speed.
        Time.timeScale = 1f;
        // Reload the current scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}