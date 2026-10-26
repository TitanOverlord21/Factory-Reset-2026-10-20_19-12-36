using UnityEngine;

public class StairCode1 : MonoBehaviour
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
        StairsForNow.StairFixed1 += FixSelf1;
        Eyes.Interacted += GoInRightPlace;
    }
    private void OnDisable()
    {
        StairsForNow.StairFixed1 -= FixSelf1;
        Eyes.Interacted -= GoInRightPlace;
    }
    private void FixSelf1()
    {
        transform.localPosition = new Vector3(1.0f, 3.0f, 8.5f);
    }

    //when interacted
    private void GoInRightPlace(string TargetStruck)
    {
        //if it's you
        if (TargetStruck == "Step 1"){
            //go in the right place
        transform.localPosition = new Vector3(1.0f, 3.0f, 8.5f);
        }
    }
}
