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
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();

    }

    private void Update()
    {
        AttackAnimation();
    }
    void FixedUpdate()
    {
       
        Death();
        Movement();
        DashPerformed();
    }
  
    void AttackAnimation()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            anim.SetInteger("AnimationType",2);
            attack = true;
            timer++;
            if (timer >= 30)
            {
                timer = 0;
            }
        }
        else
        {
            attack = false;
        }
       


    }
    public override void Death()
    {
        if (healthController.healthBar.value == 0)
        {
            soundManager.PlaySound(SOUND_FX.DEATH);
            SceneManager.LoadScene("DeathScene");
        }

    }





}
