using UnityEngine;

public class BreakableWallScript : MonoBehaviour
{
    private bool Breakable = false;
    


    private void OnEnable()
    {
        Eyes.Interacted += Break;
        Character.CanBreakWalls += MakeSelfBreakableWall;
    }
    private void OnDisable()
    {
        Eyes.Interacted -= Break;
        Character.CanBreakWalls -= MakeSelfBreakableWall;
    }

    private void MakeSelfBreakableWall(){
        Breakable = true;
    }
    private void Break(string TargetStruck){
        if (TargetStruck == gameObject.name){
            if (Breakable == true){
                // This is where we would need to trigger the break from Kyle
                Destroy(gameObject);
            }
        }
    }

}
