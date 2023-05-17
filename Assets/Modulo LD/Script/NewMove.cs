using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMove : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 5f;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        characterController.Move(transform.forward * Input.GetAxis("Horizontal") * speed * Time.deltaTime);
    }
}
