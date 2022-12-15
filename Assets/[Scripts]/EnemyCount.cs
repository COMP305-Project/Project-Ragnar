using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class EnemyCount : MonoBehaviour
{

    public int enemyLeft = 0;
    public GameObject obj;
    void Start()
    {

        enemyLeft = 5;
       
      
    }
//
    void Update()
    {
        Enemies();
    }

    public virtual void Enemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyLeft = enemies.Length;
        Debug.Log($"Enemies left : {enemyLeft}");
        if (enemyLeft < 1)
        {
            Debug.Log("Rune spawned");
            obj.SetActive(true);

        }
    }



}
