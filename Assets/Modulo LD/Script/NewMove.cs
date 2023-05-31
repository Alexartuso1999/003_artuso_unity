using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMove : MonoBehaviour
{
    [HideInInspector] public Rigidbody rgb;

    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float maxVelocity = 5f;
    [SerializeField] float distance = 5f;

    [SerializeField] GameObject player;

    private float moveHorizontal;

    private void Start()
    {
        transform.position = transform.position;
        rgb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        rgb.velocity = Vector3.ClampMagnitude(rgb.velocity, maxVelocity);
    }

    private void FixedUpdate()
    {
        if (moveHorizontal > 0.1f || moveHorizontal < -0.1f)
        {
            rgb.AddForce(transform.forward * moveHorizontal * moveSpeed, ForceMode.Acceleration);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Drag"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                other.transform.position = transform.position;
            }
        }
    }
}
