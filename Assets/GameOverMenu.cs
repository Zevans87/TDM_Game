using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    // Call this method to restart the current game scene.
    public void RestartGame()
    {
        // Optional: reset the time scale if the game was paused
        Time.timeScale = 1f;
        // Load the current active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Call this method to load the main menu scene.
    public void MainMenu()
    {
        // Optional: reset the time scale if the game was paused
        Time.timeScale = 1f;
        // Load the scene named "MainMenu" 
        SceneManager.LoadScene("MainMenu");
    }
}
