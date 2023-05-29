using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMove : MonoBehaviour
{
    [HideInInspector] public Rigidbody rgb;

    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float maxVelocity = 5f;
    [SerializeField] float distance = 5f;

    [SerializeField] LayerMask layerWall;
    
    private float moveHorizontal;

    private void Start()
    {
        rgb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        rgb.velocity = Vector3.ClampMagnitude(rgb.velocity, maxVelocity);

        RayLight();
    }

    private void FixedUpdate()
    {
        if (moveHorizontal > 0.1f || moveHorizontal < -0.1f)
        {
            rgb.AddForce(transform.forward * moveHorizontal * moveSpeed, ForceMode.Acceleration);
        }
    }

    private void RayLight()
    {
        Ray ray = new Ray(transform.position, -transform.right);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, distance, layerWall))
        {
            if (hit.transform.CompareTag("Light"))
            {
                Debug.Log("muori");
                Destroy(gameObject);
            }
        }

    }
}
