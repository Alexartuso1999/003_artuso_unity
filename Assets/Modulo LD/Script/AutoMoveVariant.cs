using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoveVariant : MonoBehaviour
{
    public float speed = 5f;


    private Vector3 move;

    private void Start()
    {
        move = transform.TransformDirection(Vector3.forward);
    }
    private void Update()
    {
        transform.Translate(move * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        move *= -1; //è la stessa cosa di scrive <move = move * (-1)>;
    }
}
