using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerLevelThree : PlayerController
{
    // Start is called before the first frame update
    void Start()
    {
        _rigidibody = GetComponent<Rigidbody2D>();
        healthController = GameObject.Find("PlayerHealthSystem").GetComponent<HealthController>();
        anim = GetComponent<Animator>();
        dodge = FindObjectOfType<DodgeBar>();
        enemyHealthSystem = FindObjectOfType<EnemyHealthSystem>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        animOne.sword = true;

    }

    // Update is called once per frame
    void Update()
    {
        Death();
      //  WeaponActiveCheck();
       // DashPerformed();
      //  Movement();
      //  Attack();
    }
    public override void Death()
    {
        if (healthController.healthBar.value == 0)
        {
            var obj = this.gameObject.GetComponent<PlayerController>();
            obj.enabled = false;
            
            soundManager.PlaySound(SOUND_FX.DEATH);
            SceneManager.LoadScene("DeathSceneLvlThree");
        }
    }
}
