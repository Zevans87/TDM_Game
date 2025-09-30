using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField] private Transform turret; // References the turret.
    [SerializeField] private Vector3 offset = new Vector3(0, 3, -5); // Adjustable camera position offset.
    [SerializeField] private float smoothSpeed = 5f; // Adjustable smoothnes of camera speed.
    void LateUpdate()
    {
        // Calculates the position of the camera based on the position of the turret and the camera offset.
        Vector3 cameraPosition = turret.position + turret.transform.rotation * offset;

        // Smoothly interpolate the camera position.
        transform.position = Vector3.Lerp(transform.position, cameraPosition, smoothSpeed * Time.deltaTime);

        // Rotate the camera as the turret rotates.
        transform.LookAt(turret.position + Vector3.up * 1.5f);
    }
}
