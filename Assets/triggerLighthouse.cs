using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerLighthouse : MonoBehaviour
{
    [SerializeField] GameObject Lighthouse;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Lighthouse.SetActive(true);
        }
    }
}
