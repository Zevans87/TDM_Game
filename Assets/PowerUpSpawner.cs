using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [Header("Power-Up Settings")]
    public GameObject powerUpPrefab;      // The power-up prefab to spawn.
    public Transform spawnCenter;         // Reference point for spawning
    public float spawnRadius = 10f;       // How far from the center the power-up can spawn.
    public float powerUpYPosition = 0f;   // Fixed Y coordinate for the power-up spawn.

    [Header("Turret Avoidance Settings")]
    public Transform turretTransform;     // Reference to the turret.
    public float minDistanceFromTurret = 5f; // Minimum distance from turret.

    [Header("Score Settings")]
    public int scoreInterval = 35;        // Spawn a power-up every 35 points.
    private int lastPowerUpScore = 0;     // The score at which the last power-up was spawned.

    void Update()
    {
        // Check if the current score has increased by scoreInterval since the last power-up spawn.
        if (ScoreManager.Instance != null &&
            ScoreManager.Instance.score - lastPowerUpScore >= scoreInterval)
        {
            SpawnPowerUp();
            // Update lastPowerUpScore by adding the interval.
            lastPowerUpScore += scoreInterval;
        }
    }

    void SpawnPowerUp()
    {
        // Calculate a random spawn position on the XZ plane around spawnCenter.
        Vector3 spawnPos = spawnCenter.position + Random.insideUnitSphere * spawnRadius;
        spawnPos.y = powerUpYPosition; // Lock the Y coordinate.

        // If turretTransform is assigned, adjust spawnPos so it's at least minDistanceFromTurret away from the turret.
        if (turretTransform != null)
        {
            float distance = Vector3.Distance(spawnPos, turretTransform.position);
            if (distance < minDistanceFromTurret)
            {
                // Calculate direction from turret to spawnPos.
                Vector3 direction = (spawnPos - turretTransform.position).normalized;
                // Reposition the power-up so it lies exactly minDistanceFromTurret away from the turret.
                spawnPos = turretTransform.position + direction * minDistanceFromTurret;
                spawnPos.y = powerUpYPosition;
            }
        }

        Instantiate(powerUpPrefab, spawnPos, Quaternion.identity);
        Debug.Log("Power-up spawned at " + spawnPos + " when score is " + ScoreManager.Instance.score);
    }
}
