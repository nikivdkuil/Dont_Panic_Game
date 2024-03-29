﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Player Properties")]
    CharacterController controller;

    [SerializeField]
    private float speed = 6f;

    [SerializeField]
    private float jumpHeight = 3f;

    [SerializeField]
    private float gravity = -9.81f;

    [SerializeField]
    private GameObject groundCheck;

    [SerializeField]
    private float groundDistance = .4f;

    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;

    private void Start()
    {
        
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.transform.position, groundDistance);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        
        controller.Move(move * speed * Time.deltaTime);
            
        

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
