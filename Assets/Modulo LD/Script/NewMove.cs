using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMove : MonoBehaviour
{
    [HideInInspector] public Rigidbody rgb;

    public float moveSpeed = 3f;
    private float moveHorizontal;
    public float maxVelocity = 5;

    private void Start()
    {
        rgb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        rgb.velocity = Vector3.ClampMagnitude(rgb.velocity, maxVelocity);
    }

    private void FixedUpdate()
    {
        if(moveHorizontal > 0.1f || moveHorizontal < -0.1f)
        {
            rgb.AddForce(transform.forward * moveHorizontal * moveSpeed, ForceMode.Acceleration);
        }
    }
}
