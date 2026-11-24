using UnityEngine;

public class NotePadButton : MonoBehaviour
{

    [SerializeField] private Timer Timer;


    private void OnEnable()
    {
        // StairsForNow.StairFixed1 += FixSelf1;
        Eyes.Interacted += ButtonIsClicked;
    }
    private void OnDisable()
    {
        // StairsForNow.StairFixed1 -= FixSelf1;
        Eyes.Interacted -= ButtonIsClicked;
    }

    private void ButtonIsClicked(string TargetStruck)
    {
        if (TargetStruck == "notePadButton")
        {
            Timer.NotePad();

        }


        if (TargetStruck == "RespawnButton")
        {
            Timer.StartLoop();

        }

        // Update is called once per frame

    }
}

