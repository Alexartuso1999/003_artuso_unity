using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementPlayer : MonoBehaviour
{
    public float speed = 5f;
    public float dashAttack = 2f;
    public float jumpHeight = 3f;
    public float height = 0.3f;
    public float dashCd;
    private float DashTimer = Mathf.Infinity;

    public int Prototype;
    public Transform groundCheck;
    public LayerMask groundMask;
    public Rigidbody rgb;

    bool isGround = true;
    bool isDash;
    bool isAttack;

    private void Update()
    {
        //movimento asse x e z
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");
        Vector3 Move = new Vector3();
        Move = (Vector3.right * xMove + Vector3.forward * zMove).normalized * speed;

        //il player si gira a seconda della direzione
        if (Move.magnitude != 0)
        {
            transform.forward = Move;
            transform.Translate(Move * Time.deltaTime, Space.World);
        }

        //salto asse y
        isGround = Physics.CheckSphere(groundCheck.position, height, groundMask);

        if (Input.GetButtonDown("Jump") && isGround)
        {
            //Move.y += Mathf.Sqrt(jumpHeight * -3f * (-9.81f));
            rgb.AddForce(transform.up * jumpHeight, ForceMode.Impulse);

        }

        Dash(); //dash attackrrrrrrrreeeeee
    }

    private void Dash()
    {
        DashTimer += Time.deltaTime;
        isDash = Input.GetKeyDown(KeyCode.Tab) && DashTimer >= dashCd;
        if (!isDash)
        {
            return;
        }
        DashTimer = 0;
        rgb.AddForce(transform.forward * dashAttack, ForceMode.Impulse);
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
            SceneManager.LoadScene("Prototype");
        }

        //Death zone
        if (collision.collider.CompareTag("Dead"))
        {
            //Destroy(player);
            SceneManager.LoadScene("Prototype");
        }

        //Win zone
        if (collision.collider.CompareTag("Win"))
        {
            SceneManager.LoadScene("Win");
        }
    }



    private void OnTriggerStay(Collider other)
    {
        isAttack = Input.GetKeyDown(KeyCode.Mouse0);
            Debug.Log("attac");
        if (other.CompareTag("Enemy") && isAttack == true)
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Chest") && isAttack == true)
        {
            Destroy(other.gameObject);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, height);
    }
}
