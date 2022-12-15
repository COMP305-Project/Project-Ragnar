using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainSceneGameController : MonoBehaviour
{

   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GameConfig.Instance().PreviousScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene("Options");
        }
    }
}
