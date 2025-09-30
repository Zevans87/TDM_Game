using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 3f;    // Speed at which the enemy moves toward the turret
    public Transform target;        // Reference to the turret

    [Header("Optional Settings")]
    public int health = 1;          // Future damage/health logic for enemy

    void Start()
    {
        
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogWarning("Enemy is missing a Rigidbody. Adding one and setting it to kinematic.");
            rb = gameObject.AddComponent<Rigidbody>();
        }
        
        rb.isKinematic = true;
        rb.useGravity = false;

        
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
        
        if (target != null)
        {
            
            Vector3 targetPos = target.position;
            targetPos.y = transform.position.y;

            
            Vector3 direction = (targetPos - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // When hit by a projectile, award score and destroy the enemy.
        if (other.CompareTag("Projectile"))
        {
            Debug.Log("Enemy hit by projectile!");

            // Only add score when the enemy is hit by a projectile.
            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.AddScore(5);
                ScoreManager.Instance.greenEnemyKills++;
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
                turretHealth.TakeDamage(5);
            }
            Destroy(gameObject);
        }
    }
}
