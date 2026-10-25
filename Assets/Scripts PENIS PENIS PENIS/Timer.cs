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
    public bool Frozen = false;


    // This script handles the timer in its entirety, everything to do with it will happen here.



    void Start()
    {
        StartPosition1 = Player.transform.position;
        StartPosition2 = CameraHolder.transform.position;

        
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

        // Pass something to open the player respawn pod
    }



    public void Loop()
    {
        loopCount++;

        Player.transform.position = StartPosition1;
        CameraHolder.transform.position = StartPosition2;

        Frozen = true;





    }
}
