using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RuneSpawnLvl3 : MonoBehaviour
{
   
    private void Start()
    {
        this.gameObject.SetActive(false);
       
       

    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
           

            Destroy(this.gameObject);
            SceneManager.LoadScene("LevelThreeCleared");

        }
    }
}
