using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disactiveLightouseInput : MonoBehaviour
{
    [SerializeField] GameObject Lighthouse;

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (other.CompareTag("Player"))
            {
                Destroy(Lighthouse);
            }
        }
    }
}
