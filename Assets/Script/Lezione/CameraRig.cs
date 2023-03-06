using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour
{
    public Transform player;
    public float cameraSensivity;
    public float distance = 3f;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.position, cameraSensivity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Camera"))
        {
            transform.position = Vector3.Lerp(transform.position, Vector3.back, distance);
        }
    }
}
