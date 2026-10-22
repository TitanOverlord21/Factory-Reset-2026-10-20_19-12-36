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
    private void OnEnable(){
        StairsForNow.StairFixed2 += FixSelf2;
    }
    private void OnDisable(){
        StairsForNow.StairFixed2 -= FixSelf2;
    }
    private void FixSelf2(){
        transform.localPosition = new Vector3(1.0f, 3.9f, 7.4f);
    }
}
