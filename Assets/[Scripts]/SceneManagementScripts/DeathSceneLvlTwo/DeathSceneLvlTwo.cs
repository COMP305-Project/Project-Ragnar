using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathSceneLvlTwo : MonoBehaviour
{
    // Start is called before the first frame update
    public void SceneLoad()
    {
        SceneManager.LoadScene("Main");
    }

    public void Restart()
    {
        
        SceneManager.LoadScene("Level2");
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
