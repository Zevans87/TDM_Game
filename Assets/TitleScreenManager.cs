using UnityEngine;

public class TitleScreenManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject titleScreenPanel;

    private void Start()
    {
        // Pause the game while the title screen is active.
        Time.timeScale = 0f;

        // Ensure the title screen is active at the start.
        if (titleScreenPanel != null)
            titleScreenPanel.SetActive(true);

        // Play title‐screen music
        if (MusicManager.Instance != null)
            MusicManager.Instance.PlayTitleMusic();
    }

   
    public void StartGame()
    {
        // Hide the title UI
        if (titleScreenPanel != null)
            titleScreenPanel.SetActive(false);

        // Resume gameplay
        Time.timeScale = 1f;

        // Switch to gameplay music
        if (MusicManager.Instance != null)
            MusicManager.Instance.PlayGameMusic();
    }
}
