using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody rb;
    Vector3 Move;
    bool isHit;
   
    private void Update()
    {
        if(isHit == false)
        {
            Move = Vector3.forward * speed * Time.deltaTime;
            transform.Translate(Move, Space.World);
        } 
        else 
        {
            Move = -Vector3.forward * speed * Time.deltaTime;
            transform.Translate(Move, Space.World);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            gameObject.transform.Rotate(0, 180, 0);
            if (isHit == false)
            {
                isHit = true;
            }
            else
            {
                isHit = false;
            }
        }
    }
}
