using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Character : MonoBehaviour
{


    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    public bool readyToJump;


    [Header("Keybinds")]

    public KeyCode jumpKey = KeyCode.Space;


    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    public    bool grounded;



    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    
    
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 1f, whatIsGround);

        MyInput();
        SpeedControl();
        
        if (grounded)
        {
            rb.linearDamping = groundDrag;
            Invoke(nameof(ResetJump), jumpCooldown);

        }
        else
        {
            rb.linearDamping = 0;
        }


    }


    private void FixedUpdate()
    {
        MovePlayer();

        if(Input.GetKey(jumpKey))
        {
            Debug.Log("awawa");
        }
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");



        // jump stuff
        if(Input.GetKey(jumpKey) && readyToJump)
        {
            readyToJump = false;
            
            Jump();

            //Invoke(nameof(ResetJump), jumpCooldown);
        }

    }


    private void MovePlayer()
    {
        // Calc movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
    
        // Apply force


        if(grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }

        // in air
        else if(!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);

        }


    }


    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }


    }

    private void Jump()
    {
        // Reset Y velocity

        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }


    private void ResetJump()
    {
        readyToJump = true;
    }















}