using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody rb;
    public LayerMask wallMask;
    Vector3 Move;
   
    private void Update()
    {
        //isWall = false;
        //transform.position += new Vector3(0, 0, speed * Time.deltaTime);
        Move = Vector3.forward * speed * Time.deltaTime;
        transform.Translate(Move, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Wall"))
        {
            gameObject.transform.Rotate(0, 180, 0);
            Move = -Vector3.forward * speed * Time.deltaTime;
            transform.Translate(Move, Space.World);
        }
    }
}
