using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float jumpHeight = 5f;
    [SerializeField] float speed = 5f;
    [SerializeField] Rigidbody rb;
    [SerializeField] LayerMask groundMask;


    public int score = 0;

    bool isGrounded;  //il bool di default è false

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if(rb != null) //!= significa "diseguale"
        {
            Debug.Log(rb.mass);
        }
        else
        {
            Debug.Log("Rigidbody not found");
        }

    }

    void Update()
    {
        //Polling input
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");

        //vettore movimento
        Vector3 playerMovement = (Vector3.right * xMove + Vector3.forward * zMove).normalized * speed;//* Time.deltaTime;
        
        //applica velocity verticale al vetore movimento
        playerMovement.y = rb.velocity.y;

        // Applico translazione
        //transform.Translate(playerMovement, Space.World);

        //CharacterController.Move(playerMovement);

        if (Input.GetButtonDown("Jump") && isGrounded) //&& significa "e", || significa "o"
        {
            //rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            playerMovement.y += Mathf.Sqrt(jumpHeight * -2f * (-9.81f));
        }

        //applica vettore movimento al rigidbody
        rb.velocity = playerMovement;


        Debug.DrawRay(transform.position + Vector3.up * 0.5f, -transform.up * 10, Color.red);

        RaycastHit hit;
        if(Physics.Raycast(transform.position + Vector3.up * 0.5f, -transform.up, out hit, 10, groundMask))
        {
            Debug.Log("Colpito");
        }

        //Physics.SphereCast
        //Physics.OverlapSphere
    }

    private void FixedUpdate() //qui gira la fisica
    {
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Collectible"))
        {
            score++;
            Debug.Log(score);
            Destroy(other.gameObject);
        }
        
        if(other.transform.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
