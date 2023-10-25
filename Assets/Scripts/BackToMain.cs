using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMain : MonoBehaviour
{ 
   
    // Start is called before the first frame update
    void Start()
    {
        SceneChanged.isChangeScenePressed = false;

    }

    public void MainSceneLoad()
    {

        SceneChanged.isChangeScenePressed = true;
        SceneManager.LoadScene("MainScene");
    }

}
