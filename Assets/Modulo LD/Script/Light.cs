using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    public GameObject player;
    public float speed = 5f;
    public float distance = 20f;

    public LayerMask mask;

    [SerializeField] GameObject checkpoint;

    private void Update()
    {
        transform.Rotate(-Vector3.up * speed * Time.deltaTime);

        LightHit();
    }

    private void LightHit()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance, mask))
        {
            if (hit.transform.CompareTag("Player"))
            {
                Destroy(player);
            }
        }
    }
}
