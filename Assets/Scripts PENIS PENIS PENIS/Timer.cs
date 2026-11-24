using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [Header("Timer")]


    public float Countdown = 10f;
    public float CountdownMax = 300f;
    public float loopCount;
    
    public GameObject Player;
    public GameObject spawnPoint;

    private Vector3 StartPosition1;
    private Vector3 StartPosition3;

    public bool Frozen = true;
    Rigidbody rb;

    [SerializeField] public GameObject Pod;


    [Header("UI")]
    public RawImage timerPLACEHOLDER;

    public TextMeshProUGUI total_time;
    public TextMeshProUGUI num_attempts;
    
    public RawImage reticle;
    public RawImage background;

    public RawImage keyBinds;
    public Image notePad;




    // This script handles the timer in its entirety, everything to do with it will happen here.

    // This will also be the script for managing UIs.
    // Use the Revitalize image in MasonUI for the interact box that respawns you.



    void Start()
    {
        StartPosition1 = spawnPoint.transform.position;
        StartPosition3 = Player.transform.position; 
        rb = Player.GetComponent<Rigidbody>();

        Loop();
    }

    void Update()
    {
        if(!Frozen)
        {
            Countdown -= Time.deltaTime;
            //Update the timer display immediately after the time changes and before the countdown is checked against 0.
            total_time.text = Countdown.ToString("F0");
            if (Countdown <= 0)
            {
                Loop();
            }


            if(Input.GetKeyDown(KeyCode.Semicolon))
            {
                Loop();
            }
        }

        




        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseMenu();
        }

    }

    public void StartLoop()
    {
        Countdown = CountdownMax;
        Frozen = false;
        rb.constraints = ~RigidbodyConstraints.FreezePosition;
        Debug.Log("Loop Start");
        Pod.SetActive(false);
        timerPLACEHOLDER.enabled = true;
        total_time.enabled = true;
        num_attempts.enabled = true;

        Player.transform.position = StartPosition1;

    }


    public void Loop()
    {
        loopCount++;
        num_attempts.text = loopCount.ToString("F0");

        
        Player.transform.position = StartPosition3;

        Frozen = true;

        rb.constraints = RigidbodyConstraints.FreezePosition;

        Debug.Log("Loop End");
        Pod.SetActive(true);
        timerPLACEHOLDER.enabled = false;
        total_time.enabled = false;
        num_attempts.enabled = false;


        //StartLoop();



    }

    public void NotePad()
    {
        notePad.enabled = true;
        background.enabled = true;


    }


    public void KeyBinds()

    {
        keyBinds.enabled = true;
        background.enabled= true;
    
    
    }


    public void CloseMenu()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        notePad.enabled = false;
        keyBinds.enabled = false;
        background.enabled = false;



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
