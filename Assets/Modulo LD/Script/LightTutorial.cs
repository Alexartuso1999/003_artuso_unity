using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTutorial : MonoBehaviour
{
    [SerializeField] GameObject check;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = check.transform.position;
        }
        else if (other.CompareTag("Drag"))
        {
            Destroy(other.gameObject);
        }
    }
}
