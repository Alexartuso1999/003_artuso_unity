using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5f;


    void Start()
    {
        
    }

    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        Vector3 horizontalMov = Vector3.right * xMove * speed * Time.deltaTime;
        transform.position += horizontalMov;

        float zMove = Input.GetAxisRaw("Vertical");
        Vector3 verticalMov = Vector3.forward * zMove * speed * Time.deltaTime;
        transform.position += verticalMov;
    }

}
