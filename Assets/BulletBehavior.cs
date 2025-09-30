using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifetime = 5f;  // Time before auto-destruction

    void Start()
    {
        // Schedule destruction after the specified lifetime
        Destroy(gameObject, lifetime);
    }

    // Using trigger collisions to avoid heavy physics responses
    private void OnTriggerEnter(Collider other)
    {
        // Make sure the "Turret" tag is defined
        if (other.CompareTag("Turret"))
            return;

        Debug.Log("Projectile hit: " + other.gameObject.name);

        // Freeze physics to prevent further collision responses
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
        }

        // Destroy the projectile upon collision
        Destroy(gameObject);
    }
}
