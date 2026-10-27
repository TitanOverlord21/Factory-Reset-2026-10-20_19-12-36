using UnityEngine;

public class StairCode1 : MonoBehaviour
{
    private string NameOfStair;
    // private float RightXValue = 0.0f;
    private float RightYValue = 3.0f;
    private float RightZValue = 8.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NameOfStair = gameObject.name;//I guess I could just use gameObject.name instead of NameOfStair every time...
        char StairNumberWord = NameOfStair[5];
        // Debug.Log("strnmbris" + StairNumberWord);
        int StairNumber = int.Parse(StairNumberWord.ToString());
        if (StairNumber != 1){
        StairNumber -= 1;
        RightYValue += (1.2585f * StairNumber);
        // Debug.Log(RightYValue + "is the y value");
        RightZValue -= (1.5f * StairNumber);
        };
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnEnable()
    {
        // StairsForNow.StairFixed1 += FixSelf1;
        Eyes.Interacted += GoInRightPlace;
    }
    private void OnDisable()
    {
        // StairsForNow.StairFixed1 -= FixSelf1;
        Eyes.Interacted -= GoInRightPlace;
    }
    // private void FixSelf1()
    // {
    //     transform.localPosition = new Vector3(0.0f, 3.0f, 8.5f);
    // }

    //when interacted
    private void GoInRightPlace(string TargetStruck)
    {
        //if it's you
        if (TargetStruck == NameOfStair){
            //go in the right place
        transform.localPosition = new Vector3(0.0f, RightYValue, RightZValue);
        }
    }
}
