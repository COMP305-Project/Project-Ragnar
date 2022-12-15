using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[System.Serializable]
public struct animValue
{
    public bool sword;
    public bool axe;
    public bool bow;
    public bool block;
}
public class PlayerController : MonoBehaviour
{
    [Header("Movement Properties")]
    public float dodgeSpeed;
    public float delay = 0.2f;
    public bool dashPerformed;
    public float _speed;
    public float _force;

    [Header("Attack System")]
    public int dmgCount;
    public bool attack;
    public int radius;
    public string direction;
    public int timer;

    [Header("Other")]
    public HealthController healthController;
    public EnemyHealthSystem enemyHealthSystem;
    public DodgeBar dodge;
    public  animValue animOne;


    protected Animator anim;
    protected Rigidbody2D _rigidibody;
    public SoundManager soundManager;

    
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

   
    void FixedUpdate()
    {
      

        Death();
        WeaponActiveCheck();
        DashPerformed();
        Movement();
        Attack();

    }

    public float xM(float x)
    {
        
        if (x > 0.0f)
        {
           transform.localRotation = Quaternion.Euler(0.0f, 0.0f, -90.0f);
            transform.localScale = new Vector2(-1, 1);
            direction = "right";
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
            transform.localScale = new Vector2(1, 1);
            direction ="left";
        }
            

        return x;
    }
    public float yM(float y)
    {
        
        if (y > 0.0f)
        {
            transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            transform.localScale = new Vector2(1, 1);
            direction="top";

        }

        else
        {
            transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            transform.localScale = new Vector2(1, -1);
            direction = "bottom";
        }
           
        return y;
    }

    protected void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // bool dodge = Input.GetKeyDown(KeyCode.Space);
        if (!animOne.bow)
        {
            if (x != 0.0f)
            {
                transform.position += new Vector3(xM(x), 0.0f, 0.0f) * Time.deltaTime * _speed;
                anim.SetInteger("AnimationType", 1);
                Dash();



            }
            else
            {
                anim.SetInteger("AnimationType", 0);


            }



            if (y != 0.0f)
            {
                transform.position += new Vector3(0.0f, yM(y), 0.0f) * Time.deltaTime * _speed;
                anim.SetInteger("AnimationType", 1);
                Dash();

            }
            else
                anim.SetInteger("AnimationType", 0);

        }
        else
            BowWalk(x, y);

    }
   

   public void Dash()
    {
        float dash = Input.GetAxisRaw("Jump");
        if (dash > 0 && direction == "right" && dodge.dodgeBar.value == 100)
        {
            // Vector3 dir= Vector3.right - this.transform.position.x;
            _rigidibody.AddForce(Vector2.right * dodgeSpeed, ForceMode2D.Impulse);
            StartCoroutine(DodgeReset());
            soundManager.PlaySound(SOUND_FX.DASH);

        }
      
        if (dash > 0 && direction == "left" && dodge.dodgeBar.value == 100)
        {
            // Vector3 dir= Vector3.right - this.transform.position.x;
            _rigidibody.AddForce(Vector2.left * dodgeSpeed, ForceMode2D.Impulse);
            StartCoroutine(DodgeReset());
            soundManager.PlaySound(SOUND_FX.DASH);

        }
       
        if (dash > 0 && direction == "top" && dodge.dodgeBar.value == 100)
        {
            // Vector3 dir= Vector3.right - this.transform.position.x;
            _rigidibody.AddForce(Vector2.up * dodgeSpeed, ForceMode2D.Impulse);
            StartCoroutine(DodgeReset());
            soundManager.PlaySound(SOUND_FX.DASH);

        }
       
        if (dash > 0 && direction == "bottom" && dodge.dodgeBar.value == 100)
        {
            // Vector3 dir= Vector3.right - this.transform.position.x;
            _rigidibody.AddForce(Vector2.down * dodgeSpeed, ForceMode2D.Impulse);
            StartCoroutine(DodgeReset());
            soundManager.PlaySound(SOUND_FX.DASH);

        }

        


    }
    protected bool DashPerformed()
    {
        float dash = Input.GetAxisRaw("Jump");
        if (dash != 0 && dodge.dodgeBar.value == 100)
            return dashPerformed = true;
        else
            return dashPerformed = false;
    }
    private IEnumerator DodgeReset()
    {
        yield return new WaitForSeconds(delay);
        _rigidibody.velocity = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        
        if (other.gameObject.CompareTag("Spike"))
        {
            HurtPlayer(10);
        }
        
     
       
        if (other.gameObject.CompareTag("GreenPotion"))
        {
            healthController.GainHealth(40);
            other.gameObject.SetActive(false);

        }
      

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("EnemyArrow"))
        {
            HurtPlayer(5);
            if (animOne.block)
                HurtPlayer(0);
        }
        if (other.gameObject.CompareTag("Ball"))
        {
            HurtPlayer(90);
            if (animOne.block)
                HurtPlayer(50);

        }
    }


    private void Attack()
    {
        WeaponActiveCheck();
        float fire = Input.GetAxisRaw("Fire1");
       
        if (animOne.axe)
        {
            if (fire > 0.0)
            {
              
                anim.SetInteger("AnimationType", 3);
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
            
        if (animOne.sword)
        {
          
            if (fire > 0.0)
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

    public void WeaponActiveCheck()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            animOne.sword = true;
            animOne.axe = false;
            animOne.bow = false;
            animOne.block = false;

        }
       
        if (Input.GetKey(KeyCode.Alpha2))
        {
            animOne.sword = false;
            animOne.axe = true;
            animOne.bow = false;
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            animOne.sword = false;
            animOne.axe = false;
            animOne.bow = true;
            animOne.block = false;
        }

       if(  animOne.axe)
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                anim.SetInteger("AnimationType", 4);
                animOne.block = true;
            }
           
            
        }
        else
        {
            animOne.block = false;
          
        }
           

    }

    //a method for detecting if the trigger is enabled on top of the player is necessary. right now, it only gets called when the player moves, then stops working until the player moves again

    public void HurtPlayer(int dmg)
    {      
         healthController.DamageTaken(dmg);
        soundManager.PlaySound(SOUND_FX.HURT);

    }
    public void HurtEnemy(int dmg)
    {
        enemyHealthSystem.DamageTaken(dmg);
    }
  
    public virtual void Death()
    {
        if (healthController.healthBar.value == 0)
        {
            soundManager.PlaySound(SOUND_FX.DEATH);
            SceneManager.LoadScene("DeathSceneLvlTwo");
        }
           
    }
    public void BowWalk(float x, float y)
    {
        if (animOne.bow)
        {
            anim.SetInteger("AnimationType", 5);
          

           

            if (x != 0.0f)
            {
                transform.position += new Vector3(xM(x), 0.0f, 0.0f) * Time.deltaTime * _speed;
                anim.SetInteger("AnimationType", 6);
                Dash();

             }
            else
                anim.SetInteger("AnimationType", 5);


            if (y != 0.0f)
            {
                transform.position += new Vector3(0.0f, yM(y), 0.0f) * Time.deltaTime * _speed;
                anim.SetInteger("AnimationType", 6);
                Dash();

            }
            else
                anim.SetInteger("AnimationType", 5);


        }

    }

   

    

}


