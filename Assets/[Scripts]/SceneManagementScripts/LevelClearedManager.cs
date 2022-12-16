using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelClearedManager : SoundController
{
    private void Start()
    {
        GetRef();
    }
    public void SceneLoad()
    {
        SceneManager.LoadScene("Level2");
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
}
