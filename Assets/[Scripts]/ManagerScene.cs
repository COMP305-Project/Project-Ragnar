using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    // Start is called before the first frame update
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
}
