using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;
    public Transform orientation;
    

    [Header("Ground Check")]
    public float playerHieght;
    public LayerMask whatIsGround;
    private bool isGrounded;


    private float horizontalInput;
    private float verticalInput;
    private Vector3 moveDirection;
    private new Rigidbody rigidbody;


    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.freezeRotation = true;
    }

    private void Update()
    {
        MyInput();
        CheckGrounded();
        SpeedControl();
    }

    private void FixedUpdate()
    {
        MovePlayer();
        
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void CheckGrounded()
    {
        // ground check
        isGrounded = Physics.Raycast(transform.position, Vector3.down, (playerHieght * 0.5f) + 0.2f, whatIsGround);

        // handle drag
        if (isGrounded == true)
        {
            rigidbody.drag = groundDrag;
        }
        else
        {
            rigidbody.drag = 0f;
        }
    }

    private void MovePlayer()
    {
        //calculate player move direction
        moveDirection = (orientation.forward * verticalInput) + (orientation.right * horizontalInput);
        rigidbody.AddForce(moveDirection * moveSpeed * 10f, ForceMode.Force); 
    }

    private void SpeedControl()
    {
        Vector3 flatVelocity = new Vector3(rigidbody.velocity.x, 0f, rigidbody.velocity.z);

        if (flatVelocity.magnitude > moveSpeed)
        {
            Vector3 limitedVelocity = flatVelocity * 0.9f;
            rigidbody.velocity = new Vector3(limitedVelocity.x, rigidbody.velocity.y, limitedVelocity.z);
        }
    }
}
