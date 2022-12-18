using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float x;
    private float z;

    public CharacterController controller;
    public float speed = 12f;
    public float jumpHeight = 3f;

    [Header("Ground Checking")]
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask whatIsGround;
    private bool isGrounded;

    private Vector3 velocity;
    private float gravity = -9.81f;

    void Start()
    {
        
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, whatIsGround);

        if(isGrounded) {
            if(velocity.y < 0) {
                velocity.y = -2f;
            }
            Debug.Log("Grounded!");
        }

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        // Movement
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Jump
        if(Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

    }
}
