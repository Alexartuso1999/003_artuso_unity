using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementPlayer : MonoBehaviour
{
    public GameObject player;
    public float speed = 5f;
    public float dashAttack = 2f;
    public int Prototype;

    public float jumpHeight = 3f;
    public float height = 0.3f;
    public Transform groundCheck;
    public LayerMask groundMask;
    public LayerMask grabMask;
    public Rigidbody rgb;
    bool isGround;
    bool isAttack;

    private void Update()
    {
        //movimento asse x e z
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");
        Vector3 Move = (Vector3.right * xMove + Vector3.forward * zMove).normalized * speed;

        //il player si gira a seconda della direzione
        if (Move.magnitude != 0)
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

        //dash attack
        if (Input.GetKeyDown(KeyCode.E))
        {
            isAttack = true;
        }
        else
        {
            isAttack = false;
        }

        if (isAttack == false)
        {
            rgb.velocity = Move;
        }

        if (isAttack == true)
        {
            Vector3 dash = Move * dashAttack;
            rgb.velocity = dash;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        //eliminare enemy o player
        if (collision.collider.CompareTag("Enemy") && isAttack == true)
        {
            Destroy(collision.collider.gameObject);
        }
        else if (collision.collider.CompareTag("Enemy"))
        {
            //Destroy(player);
            SceneManager.LoadScene(Prototype);
        }

        //Death zone
        if (collision.collider.CompareTag("Dead"))
        {
            //Destroy(player);
            SceneManager.LoadScene(Prototype);
        }
       
        //Win zone
        if (collision.collider.CompareTag("Win"))
        {
            SceneManager.LoadScene("Win");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Chest") && isAttack == true)
        {
            Debug.Log("Chest");
            Destroy(other.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, height);
    }
}
