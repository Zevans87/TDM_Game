using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    public GameObject greenEnemyPrefab; // Your existing green enemy prefab.
    public GameObject redEnemyPrefab;   // Your new red enemy prefab.

    [Header("Spawning Settings")]
    public Transform spawnCenter;       // A reference point
    public float spawnRadius = 5f;      // How far from the center enemies can spawn.
    public float spawnInterval = 2f;    // Time between spawns.
    public float enemyYPosition = 0f;   // Fixed Y coordinate for enemy spawns.

    private int redSpawnedCount = 0;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        // Check that spawnCenter is valid.
        if (spawnCenter == null)
        {
            Debug.LogWarning("Spawn center is null. Cannot spawn enemy.");
            return;
        }

        // Calculate a random spawn position on the XZ plane around spawnCenter.
        Vector3 spawnPos = spawnCenter.position + Random.insideUnitSphere * spawnRadius;
        spawnPos.y = enemyYPosition; // Lock the Y coordinate.

        // Check if we should spawn a red enemy.
        if (ScoreManager.Instance != null)
        {
            int requiredRedCount = ScoreManager.Instance.greenEnemyKills / 2;
            if (requiredRedCount > redSpawnedCount)
            {
                if (redEnemyPrefab != null)
                {
                    Debug.Log("Spawning red enemy at " + spawnPos);
                    Instantiate(redEnemyPrefab, spawnPos, Quaternion.identity);
                    redSpawnedCount++;
                    return; // Only spawn red enemy in this cycle.
                }
                else
                {
                    Debug.LogWarning("Red enemy prefab is null!");
                }
            }
        }

        // Spawn a green enemy.
        if (greenEnemyPrefab != null)
        {
            Debug.Log("Spawning green enemy at " + spawnPos);
            Instantiate(greenEnemyPrefab, spawnPos, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Green enemy prefab is null!");
        }
    }
}

