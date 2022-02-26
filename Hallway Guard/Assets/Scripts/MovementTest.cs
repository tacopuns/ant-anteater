using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour
{
 
 public CharacterController controller;

 public float speed = 12f;

 public float gravity = -9.81f;

 Vector3 velocity;

 public Transform groundCheck;

 public float groundDistance = 0.4f;

 public LayerMask groundMask;

 bool isGrounded;

 public bool isSprinting = false;
 
 public float sprintSpeed = 10.0f;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity + Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }

        if (isSprinting == true)
        {
            speed = sprintSpeed;
            //StaminaBar.instance.UseStamina(20);
        }
    }
}
