using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTutorial : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Drag"))
        {
            Destroy(other.gameObject);
        }
    }
}
