using UnityEngine;

public class StairCode3 : MonoBehaviour
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
        StairsForNow.StairFixed3 += FixSelf3;
        Eyes.Interacted += GoInRightPlace;
    }
    private void OnDisable()
    {
        StairsForNow.StairFixed3 -= FixSelf3;
        Eyes.Interacted -= GoInRightPlace;
    }
    private void FixSelf3()
    {
        transform.localPosition = new Vector3(1.0f, 4.8f, 6.3f);
    }
        private void GoInRightPlace(string TargetStruck)
    {
        //if it's you
        if (TargetStruck == "Step 3"){
            //go in the right place
        transform.localPosition = new Vector3(1.0f, 4.8f, 6.3f);
        }
    }
}
