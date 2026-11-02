using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControllerScript : MonoBehaviour
{

    public void ChangeScene(string SceneName){
        SceneManager.LoadScene(SceneName);
    }

}
