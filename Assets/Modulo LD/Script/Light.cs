using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    public float speed = 5f;
    public float distance = 20f;
   
    public LayerMask layerPlayer;
    public LayerMask layerWall;

    private void Update()
    {
        transform.Rotate(-Vector3.up * speed * Time.deltaTime);

        LightHit();
    }

    private void LightHit()
    {
        Ray forwardRay = new Ray(transform.position, transform.TransformDirection(Vector3.forward));

        if (Physics.Raycast(forwardRay, distance, layerPlayer))
        {
            Debug.Log("colpito");
        }
        else if(Physics.Raycast(forwardRay, distance, layerWall))
        {
            Debug.Log("nonColpito");
        }
    }
}
