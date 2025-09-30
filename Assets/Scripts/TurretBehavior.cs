using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehavior : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public GameObject projectilePrefab;
    public Transform firePoint;
    public float fireForce = 20f;
    public float fireRate = 0.5f;

    private float nextFireTime = 0f;
    private bool ignoreNextLeftClick = true;

    [SerializeField] private float rotationSpeed = 100f;

    [Header("Rotation Sound")]
    public AudioSource rotationAudio;  // Drag your AudioSource with the MP3 here in Inspector
    private bool wasRotating = false;

    [Header("Firing Sound")]
    public AudioClip fireSound;              // Drag your firing MP3 or WAV here
    public AudioSource fireAudioSource;     // Assign in Inspector or reuse rotationAudio


    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        float keyboardRotation = 0f;
        if (Input.GetKey(KeyCode.A))
            keyboardRotation = -1f;
        else if (Input.GetKey(KeyCode.D))
            keyboardRotation = 1f;

        float controllerRotation = Input.GetAxis("Horizontal");
        float rotationInput = (Mathf.Abs(keyboardRotation) > 0) ? keyboardRotation : controllerRotation;

        // Play/stop rotation audio
        HandleRotationAudio(rotationInput);

        // Handle firing
        bool keyboardFiring = Input.GetMouseButton(0);
        bool controllerFiring = Input.GetAxis("RightTrigger") > 0.5f;

        if ((keyboardFiring || controllerFiring) && Time.time >= nextFireTime)
        {
            if (keyboardFiring && ignoreNextLeftClick)
            {
                ignoreNextLeftClick = false;
                Debug.Log("First left click ignored. Turret will fire on subsequent clicks.");
            }
            else
            {
                Fire();
                nextFireTime = Time.time + fireRate;
            }
        }

        TurretRotation(rotationInput);
    }

    private void HandleRotationAudio(float rotationInput)
    {
        bool isRotating = Mathf.Abs(rotationInput) > 0.01f;

        if (isRotating && !wasRotating)
        {
            rotationAudio.Play();
            wasRotating = true;
        }
        else if (!isRotating && wasRotating)
        {
            rotationAudio.Stop();
            wasRotating = false;
        }
    }

    private void TurretRotation(float rotationInput)
    {
        transform.Rotate(Vector3.up * rotationInput * rotationSpeed * Time.deltaTime);
    }

    void Fire()
    {
        if (projectilePrefab != null && firePoint != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.velocity = firePoint.forward * fireForce;
            }

            // Play fire sound
            if (fireSound != null && fireAudioSource != null)
            {
                fireAudioSource.PlayOneShot(fireSound);
            }
        }
    }

}



