using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : SoundController
{
   void Start()
    {
        GetRef();
    }

    public void SceneLoad()
    {
        SceneManager.LoadScene("Main");
        ButtonClick();
    }

    public void Restart()
    {
        SceneManager.LoadScene("Main");
        ButtonClick();
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("StartMenu");
        ButtonClick();
    }

    public void Options()
    {
        GameConfig.Instance().PreviousScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("Options");
        ButtonClick();
    }
    public void BackBtnPressed()
    {
        SceneManager.LoadScene(GameConfig.Instance().PreviousScene);
        ButtonClick();
    }

    public void ToLevelThree()
    {
        SceneManager.LoadScene("Level3");
        ButtonClick();
    }

   
}
