using UnityEngine;

public class DoorScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        private void OnEnable()
    {
        // StairsForNow.StairFixed1 += FixSelf1;
        GlovesScript.GlovesOn += OpenDaDoor;
    }
    private void OnDisable()
    {
        // StairsForNow.StairFixed1 -= FixSelf1;
        GlovesScript.GlovesOn -= OpenDaDoor;
    }
    private void OpenDaDoor(){
        this.transform.eulerAngles = new Vector3(0,90,0);
    }
}
