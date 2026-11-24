using UnityEngine;

public class Timer : MonoBehaviour
{

    public float Countdown = 10f;
    public float CountdownMax = 300f;
    public float loopCount;
    
    public GameObject Player;
    public GameObject CameraHolder;

    private Vector3 StartPosition1;
    private Vector3 StartPosition2;
    public bool Frozen = true;
    Rigidbody rb;

    [SerializeField] public GameObject Pod;

    // This script handles the timer in its entirety, everything to do with it will happen here.



    void Start()
    {
        StartPosition1 = Player.transform.position;
        StartPosition2 = CameraHolder.transform.position;
        rb = Player.GetComponent<Rigidbody>();

        Loop();
    }

    void Update()
    {
        if(!Frozen)
        {
            Countdown -= Time.deltaTime;
            //Update the timer display immediately after the time changes and before the countdown is checked against 0.

            if (Countdown <= 0)
            {
                Loop();
            }
        }

        else if(Input.GetKeyDown(KeyCode.R))
        {
            StartLoop();
        }



    }

    public void StartLoop()
    {
        Countdown = CountdownMax;
        Frozen = false;
        rb.constraints = ~RigidbodyConstraints.FreezePosition;
        // Pass something to open the player respawn pod
        Debug.Log("Loop Start");
        Pod.SetActive(false);

    }



    public void Loop()
    {
        loopCount++;

        Player.transform.position = StartPosition1;
        CameraHolder.transform.position = StartPosition2;

        Frozen = true;

        rb.constraints = RigidbodyConstraints.FreezePosition;

        Debug.Log("Loop End");
        Pod.SetActive(true);


        //StartLoop();



    }

    // This is Adam's code

    private void OnEnable()
    {
        // StairsForNow.StairFixed1 += FixSelf1;
        GlovesScript.GlovesOn += MakeTimerLonger;
    }
    private void OnDisable()
    {
        // StairsForNow.StairFixed1 -= FixSelf1;
        GlovesScript.GlovesOn -= MakeTimerLonger;
    }

    private void MakeTimerLonger()
    {
        CountdownMax = 30;
    }
}
