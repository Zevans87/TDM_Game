using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    [Header("UI Reference")]
    public TextMeshProUGUI healthText; 

    [Header("Turret Reference")]
    public TurretHealth turretHealth; 

    void Update()
    {
        if (turretHealth != null && healthText != null)
        {
            // Update the UI text to display the current turret health
            healthText.text = "Health: " + turretHealth.health;
        }
    }
}
