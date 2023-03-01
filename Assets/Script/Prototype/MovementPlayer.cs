using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    //public CharacterController controller;

    public float speed = 5f;
      
    public float jumpHeight = 3f;
    public float height = 0.3f;
    public Transform groundCheck;
    public LayerMask groundMask;
    public Rigidbody rgb;
    bool isGround;

    private void Update()
    {
        //movimento asse x e z
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");
        Vector3 Move = (Vector3.right * xMove + Vector3.forward * zMove).normalized * speed;

        //il player si gira a seconda della direzione
        if(Move.magnitude != 0)
        {
            transform.forward = Move;
        }

        Move.y = rgb.velocity.y;

        //salto asse y
        isGround = Physics.CheckSphere(groundCheck.position, height, groundMask);
       
        if (Input.GetButtonDown("Jump") && isGround)
        {
           Move.y += Mathf.Sqrt(jumpHeight * -2f * (-9.81f));
        }

        rgb.velocity = Move;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Chest") && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("grab");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, height);
    }
}
