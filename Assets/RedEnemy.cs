using UnityEngine;

public class RedEnemy : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 3f;    // Speed at which the enemy moves toward the turret
    public Transform target;        // Reference to the turret
    public float strafeAmplitude = 1f;     // How far left/right the enemy strafes
    public float strafeFrequency = 2f;     // How quickly the enemy oscillates for strafing

    [Header("Optional Settings")]
    public int health = 1;          // Future damage/health logic for enemy

    void Start()
    {
        // Ensure the enemy has a Rigidbody for trigger events and that it is set properly.
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogWarning("Enemy is missing a Rigidbody. Adding one and setting it to kinematic.");
            rb = gameObject.AddComponent<Rigidbody>();
        }
        
        rb.isKinematic = true;
        rb.useGravity = false;

        // If the target isn't manually assigned, find the turret by tag.
        if (target == null)
        {
            GameObject turret = GameObject.FindGameObjectWithTag("Turret");
            if (turret != null)
            {
                target = turret.transform;
            }
            else
            {
                Debug.LogWarning("Turret not found! Please ensure your turret has the 'Turret' tag.");
            }
        }
    }

    void Update()
    {
        // Move toward the turret if a target is set, but lock the movement to the XZ plane.
        if (target != null)
        {
            // Lock movement on the XZ plane:
            Vector3 targetPos = target.position;
            targetPos.y = transform.position.y;

            // Base forward direction toward the turret.
            Vector3 directionToTarget = (targetPos - transform.position).normalized;

            // Compute a right vector (perpendicular to the direction and upward).
            Vector3 rightVector = Vector3.Cross(directionToTarget, Vector3.up).normalized;

            // Calculate a lateral offset using a sine wave.
            float lateralOffset = Mathf.Sin(Time.time * strafeFrequency) * strafeAmplitude;

            // Combine the forward direction with the lateral offset.
            Vector3 finalDirection = directionToTarget + rightVector * lateralOffset;
            finalDirection.Normalize();

            // Move the enemy.
            transform.position += finalDirection * moveSpeed * Time.deltaTime;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // When hit by a projectile, award score and destroy the enemy.
        if (other.CompareTag("Projectile"))
        {
            Debug.Log("Red Enemy hit by projectile!");

            // Only add score when the enemy is hit by a projectile.
            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.AddScore(10);
                ScoreManager.Instance.greenEnemyKills++;
            }

            // Add 10 health to the turret
            if (target != null)
            {
                TurretHealth turretHealth = target.GetComponent<TurretHealth>();
                if (turretHealth != null)
                {
                    turretHealth.AddHealth(10);
                }
            }
            Destroy(gameObject);
        }
        // When the enemy touches the turret's hit box, damage the turret and destroy the enemy.
        else if (other.CompareTag("Turret"))
        {
            Debug.Log("Enemy reached the turret!");
            TurretHealth turretHealth = other.GetComponentInParent<TurretHealth>();
            if (turretHealth != null)
            {
                turretHealth.TakeDamage(10);
            }
            Destroy(gameObject);
        }
    }
}