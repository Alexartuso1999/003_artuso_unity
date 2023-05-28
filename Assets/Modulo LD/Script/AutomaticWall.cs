using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticWall : MonoBehaviour
{
    public GameObject cube;
    public float speed = 5f;
    public Transform [] waypoints;
    //public Transform waypoint1;

    private void Update()
    {
        transform.Translate(transform.TransformDirection(Vector3.right) * speed * Time.deltaTime);
    }

   
}
