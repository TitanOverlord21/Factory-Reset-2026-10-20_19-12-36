using UnityEngine;

public class Sliding : MonoBehaviour
{

    [Header("References")]
    public Transform orientation;
    public Transform playerObj;
    private Rigidbody rb;
    private Character cr;

    [Header("Sliding")]
    public float maxSlideTime;
    public float slideForce;
    private float slideTimer;

    public float slideYscale;
    private float startYScale;

    [Header("Input")]
    public KeyCode slideKey = KeyCode.LeftControl;
    private float horizontalInput;
    private float verticalInput;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cr = GetComponent<Character>();

        startYScale = playerObj.localScale.y;


    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if(Input.GetKeyDown(slideKey) && (horizontalInput != 0 || verticalInput != 0))
        {
            StartSlide();
        }

        if(Input.GetKeyUp(slideKey) && cr.sliding)
        {
            StopSlide();
        }


    }

    private void FixedUpdate()
    {
        if (cr.sliding)
        {


            slidingMovement();
        }

    }



    private void StartSlide()
    {
        cr.sliding = true;


        playerObj.localScale = new Vector3(playerObj.localScale.x, slideYscale, playerObj.localScale.z);
        rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);

        slideTimer = maxSlideTime;
    }

    private void slidingMovement()
    {
        Vector3 inputDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;


        // slide NormalStyle
        if (!cr.onSlope() || rb.linearVelocity.y > -0.1f)
        {


            rb.AddForce(inputDirection.normalized * slideForce, ForceMode.Force);

            slideTimer -= Time.deltaTime;

            if (slideTimer <= 0)
            {
                StopSlide();
            }
        }
        // slide DownhillStyle
        else
        {
            rb.AddForce(cr.GetSlopeMoveDirection(inputDirection) * slideForce, ForceMode.Force);

        }

        
    }

    private void StopSlide()
    {
        cr.sliding = false;

        playerObj.localScale = new Vector3(playerObj.localScale.x, startYScale, playerObj.localScale.z);
    }


}
