using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RuneSpawn : MonoBehaviour
{
    RatMovementInMain rat;
    public GameObject obj;
    public GameObject closedObj;
    void Start()
    {
        rat = FindObjectOfType<RatMovementInMain>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rat.ratDeath)
        {
            obj.SetActive(true);
            closedObj.SetActive(false);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            this.gameObject.SetActive(false);
            SceneManager.LoadScene("LevelCleared");
        }
        
    }

}
