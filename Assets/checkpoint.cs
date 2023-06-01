using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    [SerializeField] GameObject check;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            check.transform.position = other.transform.position;
        }
    }
}

