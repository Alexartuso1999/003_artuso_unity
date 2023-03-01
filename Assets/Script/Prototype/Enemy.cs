using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody rb;
    public LayerMask wallMask;
   
    private void Update()
    {
        transform.position += new Vector3(0, 0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Wall"))
        {
            gameObject.transform.Rotate(0, 180, 0);

            
            //transform.position += new Vector3(0, 0, -speed * Time.deltaTime);
            //non riesco a farlo andare nella direzione inversa dio lupo!
            //rb.AddForce(transform.forward * speed * Time.deltaTime);
        }
    }
}
