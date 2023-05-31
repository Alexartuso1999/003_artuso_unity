using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heavyBox : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    private Vector3 move;

    private void Update()
    {
        transform.Translate(move * speed * Time.deltaTime);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            move = transform.TransformDirection(-Vector3.right); 
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            move *= -1;
            transform.position = transform.position;
        }
    }
}
