using UnityEngine;
using System.Collections;

public class TurretHealth : MonoBehaviour
{
    public int health = 100;  // Starting health
    public bool isInvincible = false; // Tracks invincibility

    
    public void TakeDamage(int damage)
    {

        health -= damage;
        Debug.Log("Turret took " + damage + " damage. Remaining health: " + health);

        if (health <= 0)
        {
            Debug.Log("Turret destroyed!");
            if (GameOverManager.Instance != null)
            {
                GameOverManager.Instance.GameOver();
            }
        }
    }

    public void AddHealth(int amount)
    {
        health += amount;
        Debug.Log("Turret gained " + amount + " health. Total health: " + health);
    }

}
