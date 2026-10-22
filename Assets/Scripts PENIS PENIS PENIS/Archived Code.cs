// -------------------------------------------------
//            grappling hook 1.0
// -------------------------------------------------


//using UnityEngine;

//public class GrapplingHookBaby : MonoBehaviour
//{
//    [Header("Input")]

//    public KeyCode swingKey = KeyCode.Mouse0;
//    [Header("References")]
//    public LineRenderer lr;
//    public Transform gunTip, cam, player;
//    public LayerMask whatIsGrappleable;

//    [Header("Swinging")]
//    private float maxSwingDistance = 1000f;
//    private Vector3 swingPoint;
//    private SpringJoint joint;


//    private Vector3 currentGrapplePosition;


//    private void StartSwing()
//    {
//        RaycastHit hit;
//        if (Physics.Raycast(cam.position, cam.forward, out hit, maxSwingDistance, whatIsGrappleable))
//        {
//            swingPoint = hit.point;
//            joint = player.gameObject.AddComponent<SpringJoint>();
//            joint.autoConfigureConnectedAnchor = false;
//            joint.connectedAnchor = swingPoint;

//            float distanceFromPoint = Vector3.Distance(player.position, swingPoint);

//            joint.maxDistance = distanceFromPoint * 1f;
//            joint.minDistance = distanceFromPoint * 0.25f;

//            joint.spring = 4.5f;
//            joint.damper = 7f;
//            joint.massScale = 4.5f;

//            lr.positionCount = 2;
//            currentGrapplePosition = gunTip.position;
//        }
//    }

//    private void StopSwing()
//    {
//        lr.positionCount = 0;
//        Destroy(joint);
//    }

//    void DrawRope()
//    {
//        if (!joint) return;

//        currentGrapplePosition = Vector3.Lerp(currentGrapplePosition, swingPoint, Time.deltaTime * 8f);

//        lr.SetPosition(0, gunTip.position);
//        lr.SetPosition(1, swingPoint);
//    }



//    // Start is called once before the first execution of Update after the MonoBehaviour is created
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        float scrollDelta = Input.mouseScrollDelta.y;


//        if (Input.GetKeyDown(swingKey)) StartSwing();
//        if (Input.GetKeyUp(swingKey)) StopSwing();
//        if (scrollDelta > 0f)
//        {
//            joint.maxDistance = joint.maxDistance * 1.1f;
//            joint.minDistance = joint.minDistance * 1.1f;
//        }
//        else if (scrollDelta < 0f)
//        {
//            joint.maxDistance = joint.maxDistance * 0.9f;
//            joint.minDistance = joint.minDistance * 0.9f;
//        }

//    }

//    private void LateUpdate()
//    {
//        DrawRope();
//    }


//}


// -------------------------------------------------
//            eyes 1.0
// -------------------------------------------------


//using UnityEngine;

//public class Eyes : MonoBehaviour
//{


//    public float lookSensitivity = 2.0f;
//    public float rollSpeed = 50f;

//    void Start()
//    {
//        // Lock and hide the cursor for first-person control
//        Cursor.lockState = CursorLockMode.Locked;
//        Cursor.visible = false;
//    }

//    void Update()
//    {
//        HandleRotation();
//    }

//    void HandleRotation()
//    {
//        // 1. Capture raw mouse input
//        float mouseX = Input.GetAxis("Mouse X") * lookSensitivity;
//        float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity;

//        // 2. Capture local Roll input (Q and E keys)
//        float rollInput = 0f;
//        if (Input.GetKey(KeyCode.Q)) rollInput += 1f;
//        if (Input.GetKey(KeyCode.E)) rollInput -= 1f;

//        // 3. Apply local rotations sequentially to prevent locking
//        // Pitch (Up/Down) around the local X axis
//        transform.Rotate(Vector3.left * mouseY, Space.Self);

//        // Yaw (Left/Right) around the local Y axis
//        transform.Rotate(Vector3.up * mouseX, Space.Self);

//        // Roll (Bank) around the local Z axis
//        transform.Rotate(Vector3.forward * rollInput * rollSpeed * Time.deltaTime, Space.Self);
//    }


//}

// -------------------------------------------------
//            Player Movement 1.0
// -------------------------------------------------



//using System.Collections;
//using UnityEngine;
// ----------------------------------------------------------------------------------------------------------------------

// Take notes here!!
// Charles [This all works, it is perfectly functional right now and you SHOULD SAVE A BACKUP SOMEWHERE PLEASE PLEASE DON'T FUCK YOURSELF HERE.
// You can't walk through the air right now, but you can walk up walls, and when you stop you shoot back down.
// Making the parts of the level that are floors be in the layer Wall, while the tag ground, can differentiate them, and then implement whatever fix;
// potential fixes
// 1. player cannot walk while touching a wall and not ground, would have to remove the ground tag from the walls.
// 2. Amplify the force of the gravity script somehow
// 3. Greatly reduce player max speed
// 4. This can just stay, technically? I guess? Leaving it in might be fine, but it's very possible that this could seriously mess up level design later on]

// ----------------------------------------------------------------------------------------------------------------------

//public class Character : MonoBehaviour
//{
//    private CharacterController characterController;
//    public float Speed = 2f;
//    public float jumpForce = 30f;
//    private Rigidbody rb;
//    public bool isGrounded = true;
//    //private float AirControl = 0.02f;
//    private float sprintMult = 1.8f;
//    public float maxSpeed = 10f;
//    public float Stop = 0.01f;


//    // Start is called once before the first execution of Update after the MonoBehaviour is created
//    void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//        characterController = GetComponent<CharacterController>();
//        rb.constraints = RigidbodyConstraints.FreezeRotation;



//    }

//    // Update is called once per frame
//    void Update()
//    {
//        float horizontal = Input.GetAxis("Horizontal");
//        float vertical = Input.GetAxis("Vertical");
//        //Vector3 direction = new Vector3(horizontal, 0, vertical);

//        Vector3 direction = (transform.forward * vertical) + (transform.right * horizontal);



//        //if (!isGrounded)
//        //    {
//        //    rb.linearVelocity += (direction * Speed * AirControl);
//        //    }

//        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
//        {
//            rb.linearVelocity += (direction * Speed * sprintMult);
//        }

//        if (!Input.GetKey(KeyCode.LeftShift) && isGrounded)
//        {
//            rb.linearVelocity += (direction * Speed);
//        }

//        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
//        {
//            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
//            isGrounded = false;
//        }

//        if (rb.linearVelocity.magnitude > maxSpeed && isGrounded && !Input.GetKeyDown(KeyCode.LeftShift))
//        {
//            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
//        }

//        if (rb.linearVelocity.magnitude > maxSpeed && isGrounded && Input.GetKeyDown(KeyCode.LeftShift))
//        {
//            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed * sprintMult;
//        }

//        //Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
//        //characterController.Move(move * Time.deltaTime * Speed);

//        if (rb.linearVelocity.sqrMagnitude <= (Stop * Stop))
//        {
//            isGrounded = true;
//        }


//    }


//    private void OnCollisionEnter(Collision collision)
//    {
//        if (collision.gameObject.CompareTag("Ground"))
//        {
//            isGrounded = true;
//        }

//    }


//    IEnumerator WaitAndChangeVariable(float timeToWait)
//    {
//        yield return new WaitForSeconds(timeToWait);
//        isGrounded = false;
//    }


//    private void OnCollisionExit(Collision collision)
//    {
//        if (collision.gameObject.CompareTag("Ground"))
//        {
//            StartCoroutine(WaitAndChangeVariable(0.2f));
//        }

//    }
//}