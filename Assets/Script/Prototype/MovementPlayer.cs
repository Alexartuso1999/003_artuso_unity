using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 5f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVel;
      
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
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");
        Vector3 Move = new Vector3(xMove, 0f, zMove).normalized * speed;

        if(Move.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(Move.x, Move.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVel, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            controller.Move(Move * speed * Time.deltaTime);
        }
        
        //salto asse y
        isGround = Physics.CheckSphere(groundCheck.position, height, groundMask);
        Move.y = rgb.velocity.y;
       
        if(isGround && velocity.y < 0)
        {
            velocity.y = -10f;
        }
        if (Input.GetButtonDown("Jump") && isGround)
        {
           velocity.y += Mathf.Sqrt(jumpHeight * -2f * (-9.81f));
        }

        velocity.y += (-9.81f) * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Chest") && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("grab");
        }
    }
}
