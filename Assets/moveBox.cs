using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBox : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    Vector3 move;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            move = transform.TransformDirection(Vector3.right);
        }
    }

    private void Update()
    {
        transform.Translate(move * speed * Time.deltaTime);
    }
}
