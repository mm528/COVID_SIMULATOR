using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstScene : MonoBehaviour
{
    // Start is called before the first frame update

    public void StartGame(){
            SceneManager.LoadScene("Main_Game");

    }
    public void ExitGame(){
                Application.Quit();
             UnityEditor.EditorApplication.isPlaying = false;
    }

    public void StarGame2(){
        SceneManager.LoadScene("Update_Scene");
    }
}
