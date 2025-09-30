//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class TurretShooting : MonoBehaviour
//{
//    [SerializeField] private GameObject bulletPrefab;
//    [SerializeField] private Transform firePoint; // The point where bullets should spawn
//    [SerializeField] private float fireRate = 1f; // Time between shots
//    private float nextFireTime = 0f;

//    void Update()
//    {
//        if (Time.time >= nextFireTime)
//        {
//            if (Input.GetButton("Fire1")) // Assuming Fire1 is the input for firing
//            {
//                FireBullet();
//                nextFireTime = Time.time + 1f / fireRate;
//            }
//        }
//    }

//    void FireBullet()
//    {
//        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
//        Rigidbody rb = bullet.GetComponent<Rigidbody>();
//        rb.velocity = firePoint.forward * 20f; // Adjust this for bullet speed
//    }
//}
