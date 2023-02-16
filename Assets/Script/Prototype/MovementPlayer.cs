using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] public float speed = 5f;
    [SerializeField] public float jumpHeight = 3f;
    [SerializeField] Rigidbody rgb;
    bool isGround;

    private void Update()
    {
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");

        Vector3 Move = (Vector3.right * xMove + Vector3.forward * zMove).normalized * speed * Time.deltaTime;

        transform.Translate(Move, Space.World);
        Move.y = rgb.velocity.y;

        if (Input.GetButtonDown("Jump") && isGround)
        {
            Move.y += Mathf.Sqrt(jumpHeight * -2f * (-9.81f));
        }
    }

   
}
