using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelClearedManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void SceneLoad()
    {
        SceneManager.LoadScene("Level2");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Main");
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
