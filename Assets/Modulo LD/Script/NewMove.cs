using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMove : MonoBehaviour
{
    [HideInInspector] public Rigidbody rgb;

    public float moveSpeed = 3f;
    private float moveHorizontal;
    public float maxVelocity = 5;

    Ray ray;
    public float rayDistance = 5f;
    public LayerMask layer;
    public LayerMask layerWall;

    private void Start()
    {
        rgb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        rgb.velocity = Vector3.ClampMagnitude(rgb.velocity, maxVelocity);

       //ray = new Ray(transform.position, transform.right * (-1f));
        //Debug.DrawRay(transform.position, transform.right * (-1f), Color.red);

        CheckLight();

    }

    private void FixedUpdate()
    {
        if(moveHorizontal > 0.1f || moveHorizontal < -0.1f)
        {
            rgb.AddForce(transform.forward * moveHorizontal * moveSpeed, ForceMode.Acceleration);
        }
    }

    void CheckLight()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.right * (-1f), out hit, rayDistance, layer))
        {
            Debug.DrawRay(transform.position, transform.right * (-1f), Color.red, rayDistance);
            GameObject.Destroy(gameObject);
        }
        else if (Physics.Raycast(transform.position, transform.right * (-1f), out hit, rayDistance, layerWall))
        {

        }
    }
}
