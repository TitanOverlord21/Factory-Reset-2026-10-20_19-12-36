using UnityEngine;
using UnityEngine.Animations;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public KeyCode jumpKey = KeyCode.Space;
    public float jumpForce = 20f;

    private CharacterController characterController;



    void Start()
    {
        characterController = GetComponent<CharacterController>();

       
    }

    void Update()
    {
        

        HandleMovement();
        
    }

   

    void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = (transform.forward * moveZ) + (transform.right * moveX);
        moveDirection.Normalize();

        
        

        Vector3 finalVelocity = (moveDirection * moveSpeed);

        if (Input.GetKeyDown(jumpKey))
        {
            finalVelocity.y = jumpForce;
        }


        characterController.Move(finalVelocity * Time.deltaTime);
    }
}
