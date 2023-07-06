using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbPlayer : MonoBehaviour
{
    public float speed = 5f;
    public float distance = 0.5f;
    public LayerMask whatIsWall;

    private void Update()
    {
        RaycastHit climb;
        float yMove = Input.GetAxis("Horizontal");

        if (Physics.Raycast(transform.position, transform.forward, out climb, distance, whatIsWall, QueryTriggerInteraction.Collide))
        {
            Debug.Log("muori pd");
            transform.Translate(Vector3.up * speed * yMove * Time.deltaTime);
        }
    }
}
