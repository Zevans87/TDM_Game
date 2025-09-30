using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularPath : MonoBehaviour
{
    public Transform target; //Gives UFO a target to rotate around
    public float speed = .2f;//Speed of Movement
    public float radius = 300f;//Radius of the circle path
    public float angle = 0f;//angle of the object
    public float height = 33.2f;//Height of the UFO

    // Update is called once per frame
    void Update()
    {
        
        float x = target.position.x + Mathf.Cos(angle) * radius;
        float y = height;//The UFO will follow the Variable set for Height
        float z = target.position.z + Mathf.Sin(angle) * radius;

        //position update
        transform.position = new Vector3(x, y, z);

        //Increment the angle to move the object along the circular path

        angle += speed * Time.deltaTime;

        angle %= 2 * Mathf.PI;
    }
}
