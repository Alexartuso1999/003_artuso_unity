using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    CharacterController controller;

    public float speed = 5f;
    
    public float jumpHeight = 3f;
    public float height = 0.01f;
    public Transform groundCheck;
    public LayerMask groundMask;
    public Rigidbody rgb;
    bool isGround;
    Vector3 velocity;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    private void Update()
    {
        //movimento asse x e z
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");
        Vector3 Move = transform.right * xMove + transform.forward * zMove;
        controller.Move(Move * speed * Time.deltaTime);        

        //salto asse y
        isGround = Physics.CheckSphere(groundCheck.position, height, groundMask);
        Move.y = rgb.velocity.y;
       
        if(isGround && velocity.y < 0)
        {
            velocity.y = -0.5f;
        }
        if (Input.GetButtonDown("Jump") && isGround)
        {
           velocity.y += Mathf.Sqrt(jumpHeight * -2f * (-9.81f));
        }

        velocity.y += (-9.81f) * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

   
}
