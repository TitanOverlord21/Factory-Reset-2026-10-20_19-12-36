using UnityEngine;

public class StairCode2 : MonoBehaviour
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
        StairsForNow.StairFixed2 += FixSelf2;
        Eyes.Interacted += GoInRightPlace;
    }
    private void OnDisable()
    {
        StairsForNow.StairFixed2 -= FixSelf2;
        Eyes.Interacted -= GoInRightPlace;
    }
    private void FixSelf2()
    {
        transform.localPosition = new Vector3(1.0f, 3.9f, 7.4f);
    }

    private void GoInRightPlace(string TargetStruck)
    {
        //if it's you
        if (TargetStruck == "Step 2"){
            //go in the right place
        transform.localPosition = new Vector3(1.0f, 3.9f, 7.4f);
        }
    }
}
