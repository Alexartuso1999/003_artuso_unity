using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbPlayer : MonoBehaviour
{
    public float speed = 5f;
    public float height = 0.3f;
    bool canClimb;
    bool isWall;
    public Transform wallCheck;
    public Rigidbody rb;
    public LayerMask whatIsWall;

    private void Update()
    {
        float yMove = Input.GetAxis("Vertical");

        isWall = Physics.CheckSphere(wallCheck.position, height, whatIsWall);

        if (isWall == true)
        {
            canClimb = true;
        }
        else
        {
            canClimb = false;
        }

        if(canClimb == true)
        {
            Vector3 Move = Vector3.up * yMove * speed;
            rb.velocity = Move;
        }
    }
}
