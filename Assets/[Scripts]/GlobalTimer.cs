using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalTimer : MonoBehaviour
{
    public float attackBuffer = 1f;
    public float boxTimer = 1f;
    public float despawnBox = 0.25f;
    public GameObject attack;

    public HealthController health;
    // Start is called before the first frame update
    void Start()
    {
        
        health = GetComponent<HealthController>();
        attack = GameObject.Find("Melee");
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.GetComponent<EnemyController>().canAttack)
        {
            if (attackBuffer > 0)
            {
                attackBuffer -= Time.deltaTime;
            }
            else
            {
                //Debug.Log("Times up!");
                this.GetComponent<EnemyController>().canAttack = true;
               
            }
        }
        if (this.GetComponent<EnemyController>().showBox)
        {
            if (boxTimer > 0)
            {
                boxTimer -= Time.deltaTime;
            }
            else
            {
                //Debug.Log("Times up!");
                attack.GetComponent<SpriteRenderer>().enabled = true;
                attack.GetComponent<Collider2D>().enabled = true;
                this.Attack();
                
            
            }
        }
    }

    void Attack()
    {
        if (despawnBox > 0)
        {
            despawnBox -= Time.deltaTime;
        }
        else
        {
            //Debug.Log("Times up!");
            despawnBox = 0.25f;
            this.GetComponent<EnemyController>().showBox = false;
            attack.GetComponent<SpriteRenderer>().enabled = false;
            attack.GetComponent<Collider2D>().enabled = false;
        }
    }
}
