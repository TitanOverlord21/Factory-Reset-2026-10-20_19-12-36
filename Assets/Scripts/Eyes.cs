using UnityEngine;

public class Eyes : MonoBehaviour
{
    public float mouseSensitivity = 2f;

    public Transform playerBody;


    public KeyCode lRoll = KeyCode.E;
    public KeyCode rRoll = KeyCode.Q;



    private float xRotation;
    private float yRotation;

    public float rollSpeed = 2.0f;



    private GrapplingHookBaby GH = null;
    private Camera CAM = null;
            

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        GH = GameObject.Find("Player").GetComponent<GrapplingHookBaby>();
        CAM = GameObject.Find("PlayerCam1st").GetComponent<Camera>();

    }

    void Update()
    {


       
            if (GH.isSwinging)
            {
                HandleRotationAir();
            }
            else
            {
                float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
                float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

                xRotation -= mouseY;
                xRotation = Mathf.Clamp(xRotation, -90f, 90f);

                yRotation += mouseX;
                //yRotation = Mathf.Clamp(yRotation, -90f, 90f);

                transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);

                //playerBody.Rotate(Vector3.up * mouseX);
            }

    }

        void HandleRotationAir()
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            float rollInput = 0f;
            if (Input.GetKey(lRoll)) rollInput += 1f;
            if (Input.GetKey(rRoll)) rollInput -= 1f;


            transform.Rotate(Vector3.left * mouseY, Space.Self);

            transform.Rotate(Vector3.up * mouseX, Space.Self);

            transform.Rotate(Vector3.forward * rollInput * rollSpeed * Time.deltaTime, Space.Self);
        }

        // Get mouse movement inputs
       
    }














//      Not functional!! This does not work, but may have important components.
//using UnityEngine;
////using UnityEngine.UIElements;

//public class Eyes : MonoBehaviour
//{

//    public float rotationSpeed = 180; // Degrees per second


//    public float lookSensitivity = 2.0f;
//    public float rollSpeed = 50f;
//    private GrapplingHookBaby GH = null;
//    private Camera CAM = null;

//    void Start()
//    {
//        // Lock and hide the cursor for first-person control
//        Cursor.lockState = CursorLockMode.Locked;
//        Cursor.visible = false;
//        GH = GameObject.Find("Player").GetComponent<GrapplingHookBaby>();
//        CAM = GameObject.Find("PlayerCam1st").GetComponent<Camera>();

//    }

//    void Update()
//    {
//        if(GH.isSwinging)
//        {
//            HandleRotationAir();
//        }
//        else
//        {
//            HandleRotationGround();
//        }

//    }

//    void HandleRotationAir()
//    {
//        float mouseX = Input.GetAxis("Mouse X") * lookSensitivity;
//        float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity;

//        float rollInput = 0f;
//        if (Input.GetKey(KeyCode.Q)) rollInput += 1f;
//        if (Input.GetKey(KeyCode.E)) rollInput -= 1f;


//        transform.Rotate(Vector3.left * mouseY, Space.Self);

//        transform.Rotate(Vector3.up * mouseX, Space.Self);

//        transform.Rotate(Vector3.forward * rollInput * rollSpeed * Time.deltaTime, Space.Self);
//    }
//    void HandleRotationGround()
//    {
//        float mouseX = Input.GetAxis("Mouse X") * lookSensitivity;
//        float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity;

//        CAM.transform.Rotate(Vector3.left * mouseY, Space.Self);
//        CAM.transform.Rotate(Vector3.up * mouseX, Space.Self);

//        if(transform.eulerAngles.z != 0)
//        {
//            Quaternion currentRotation = transform.rotation;

//            Vector3 forward = transform.forward;
//            Quaternion targetRotation = Quaternion.LookRotation(forward, Vector3.up);

//            CAM.transform.rotation = Quaternion.RotateTowards(currentRotation, targetRotation, rotationSpeed * Time.deltaTime
//            );
//        }

//    }

//}


//This is functional, but it doesn't work if you're sideways. It needs to do that.
//using UnityEngine;

//public class Eyes : MonoBehaviour
//{
//    public float sensitivity = 2.0f;
//    private float rotationX = 0.0f;
//    private float rotationY = 0.0f;

//    void Start()
//    {
//        Cursor.lockState = CursorLockMode.Locked;
//        Cursor.visible = false;

//        Vector3 currentAngles = transform.eulerAngles;
//        rotationX = currentAngles.y;
//        rotationY = currentAngles.x;
//    }

//    void Update()
//    {
//        // 1. Capture raw mouse input
//        float inputX = Input.GetAxis("Mouse X") * sensitivity;
//        float inputY = Input.GetAxis("Mouse Y") * sensitivity;

//        // 2. Check if the object's Up vector points down relative to world Up
//        // If Dot product is negative, the player is upside down
//        bool isUpsideDown = Vector3.Dot(transform.up, Vector3.up) < 0;

//        // 3. If upside down, invert the horizontal axis to compensate for the flip
//        if (isUpsideDown)
//        {
//            rotationX -= inputX;
//        }
//        else
//        {
//            rotationX += inputX;
//        }

//        rotationY -= inputY;

//        // 4. Update the actual rotation of the player entity (carrying the camera)
//        transform.rotation = Quaternion.Euler(rotationY, rotationX, 0);
//    }
//}


// -------------------------------------------------------------------------

//using System.IO;
//using UnityEngine;

//public class Eyes : MonoBehaviour
//{

//    public Vector2 turn;
//    public float sensitivity = .5f;

//    // Start is called once before the first execution of Update after the MonoBehaviour is created
//    void Start()
//    {
//        Cursor.lockState = CursorLockMode.Locked;

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        turn.x += Input.GetAxis("Mouse X");
//        turn.y += Input.GetAxis("Mouse Y");
//        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);

//        if (Input.GetKeyDown(KeyCode.Escape))
//        {
//            Cursor.lockState = CursorLockMode.None;
//        }

//        if (Input.GetKeyDown(KeyCode.E))
//        {
//            Cursor.lockState = CursorLockMode.Locked;
//        }


//    }
//}
