using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerControllerInMain : PlayerController
{

   

    void Start()
    {
        _rigidibody = GetComponent<Rigidbody2D>();
        healthController = GameObject.Find("PlayerHealthSystem").GetComponent<HealthController>();
        anim = GetComponent<Animator>();
     
        dodge = FindObjectOfType<DodgeBar>();
        enemyHealthSystem = FindObjectOfType<EnemyHealthSystem>();
       
    }
    private void Update()
    {
        if (healthController.healthBar.value == 0)
            SceneManager.LoadScene("DeathScene");
        AttackInMain();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
        Movement();
        DashPerformed();
    }
    protected override void AttackInMain()
    {



        if (Input.GetKey(KeyCode.Mouse0))
        {
            anim.SetInteger("AnimationType", 2);
            timer++;
            if (timer >= 30)
            {
                timer = 0;
            }
            attack = true;

        }
        else
        {
            attack = false;
        }


    }

}
