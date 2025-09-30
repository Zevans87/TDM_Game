////using System.Collections;
////using System.Collections.Generic;
////using UnityEngine;

////public class BulletBehavior : MonoBehaviour
////{
////    [SerializeField] private float speed = 20f;
////    [SerializeField] private float lifeTime = 3f;

////    private Rigidbody rb;

////    void Start()
////    {
////        //    rb = GetComponent<Rigidbody>();

////        //    // Ensure that the bullet follows a forward trajectory.
////        //    rb.velocity = transform.forward * speed;

////        //    // Destroy bullet projectile if it does not hit anything after an adjustable amount of time.
////        //    Destroy(gameObject, lifeTime); 
////    }

////    void Update()
////    {
////        rb = GetComponent<Rigidbody>();

//        // Freeze rotation to prevent spinning
//        rb.freezeRotation = true;

//        // Ensure that the bullet follows a forward trajectory with Rigidbody velocity.
//        rb.velocity = transform.forward * speed;
//        // Ensure that the bullet follows a forward trajectory.
//        rb.velocity = transform.forward * speed;
////        // Ensure that the bullet follows a forward trajectory.
////        rb.velocity = transform.forward * speed;

//        // Destroy bullet projectile if it does not hit anything after an adjustable amount of time.
//        Destroy(gameObject, lifeTime);
//    }
//        // Destroy bullet projectile if it does not hit anything after an adjustable amount of time.
//        Destroy(gameObject, lifeTime); 
//    }
////        // Destroy bullet projectile if it does not hit anything after an adjustable amount of time.
////        Destroy(gameObject, lifeTime);

//    // Remove Update() method since you're already using Rigidbody velocity.
//}
//    void Update()
//    {
//        transform.Translate(Vector3.forward * speed * Time.deltaTime);
//    }
//}
////        transform.Translate(Vector3.forward * speed * Time.deltaTime);
////    }
////}
