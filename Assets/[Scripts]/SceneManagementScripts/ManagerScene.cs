using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    
   public void SceneLoad()
    {
        SceneManager.LoadScene("Main");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Main");
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void Options()
    {
        GameConfig.Instance().PreviousScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("Options");
    }
    public void BackBtnPressed()
    {
        SceneManager.LoadScene(GameConfig.Instance().PreviousScene);
    }

    public void ToLevelThree() => SceneManager.LoadScene("Level3");

   
}
