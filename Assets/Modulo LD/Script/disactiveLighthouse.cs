using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disactiveLighthouse : MonoBehaviour
{
    [SerializeField] GameObject Lighthouse;

    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (other.CompareTag("Player"))
            {
                Lighthouse.SetActive(false);
            }
        }
    }
}
