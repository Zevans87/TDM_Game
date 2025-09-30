using UnityEngine;

public class PowerUpBehavior : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // When the power-up is hit by a projectile, clear enemies and reset the kill counter.
        if (other.CompareTag("Projectile"))
        {
            Debug.Log("Power-up hit by projectile! Clearing all enemies and resetting kill counter.");
            ClearAllEnemies();

            // Reset the green enemy kill counter (used for spawning red enemies) without affecting the player's score.
            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.greenEnemyKills = 0;
                Debug.Log("Green enemy kill counter reset.");
            }

            Destroy(gameObject);
        }
    }

    // This method finds all enemy objects (which should be tagged "Enemy") and destroys them.
    void ClearAllEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        Debug.Log("All enemies cleared from the scene.");
    }
}
