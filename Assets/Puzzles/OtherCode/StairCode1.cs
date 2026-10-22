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
    }
    private void OnDisable()
    {
        StairsForNow.StairFixed1 -= FixSelf1;
    }
    private void FixSelf1()
    {
        transform.localPosition = new Vector3(1.0f, 3.0f, 8.5f);
    }
}
