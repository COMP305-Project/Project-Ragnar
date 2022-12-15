using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RuneSpawnLvl2 :SoundController
{
 
    private void Start()
    {
        this.gameObject.SetActive(false);
        GetRef();
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name=="Player")
        {
            EnemyCount enemyCount = GameObject.FindObjectOfType<EnemyCount>();
            enemyCount.gameObject.SetActive(false);
            PlayRune();
            Destroy(this.gameObject);
            SceneManager.LoadScene("LevelTwoCleared");
            
        }
    }
}
