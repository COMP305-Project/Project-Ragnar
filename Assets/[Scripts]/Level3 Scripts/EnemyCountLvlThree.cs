using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCountLvlThree :EnemyCount
{
    public GameObject objTwo;
    void Start()
    {
        enemyLeft = 4;
    }

    // Update is called once per frame
    void Update()
    {
        Enemies();
    }
    public override void Enemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyLeft = enemies.Length;
        Debug.Log($"Enemies left : {enemyLeft}");
        if (enemyLeft < 1)
        {
            Debug.Log("Door Opened");
            obj.SetActive(false);
            objTwo.SetActive(true);

        }
    }
}
