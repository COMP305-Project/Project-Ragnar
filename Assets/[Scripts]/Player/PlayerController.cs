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
    public float _speed;
    public float _force;
  
   protected Rigidbody2D _rigidibody;
    public int dmgCount;
    public bool startChase;
    public bool endChase;   
    public HealthController healthController;
    public EnemyHealthSystem enemyHealthSystem;
    public DodgeBar dodge;
    public bool attack;
    public int radius;
    public string direction;
     protected Animator anim;
   
    
    public float dodgeSpeed;
    public float delay = 0.2f;
    public bool dashPerformed;

    public int timer;
    
   public  animValue animOne;
   
    // Start is called before the first frame update
    void Start()
    {
        _rigidibody = GetComponent<Rigidbody2D>();
       healthController = GameObject.Find("PlayerHealthSystem").GetComponent<HealthController>();
        anim = GetComponent<Animator>();
        dodge = FindObjectOfType<DodgeBar>();
        enemyHealthSystem = FindObjectOfType<EnemyHealthSystem>();
        animOne.sword = true;
       
       
    }

    // Update is called once per frame
   
    void FixedUpdate()
    {

        if (healthController.healthBar.value == 0)
            SceneManager.LoadScene("DeathSceneLvlTwo");

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
   

    private void Dash()
    {
        float dash = Input.GetAxisRaw("Jump");
        if (dash > 0 && direction == "right" && dodge.dodgeBar.value == 100)
        {
            // Vector3 dir= Vector3.right - this.transform.position.x;
            _rigidibody.AddForce(Vector2.right * dodgeSpeed, ForceMode2D.Impulse);
            StartCoroutine(DodgeReset());
           
        }
      
        if (dash > 0 && direction == "left" && dodge.dodgeBar.value == 100)
        {
            // Vector3 dir= Vector3.right - this.transform.position.x;
            _rigidibody.AddForce(Vector2.left * dodgeSpeed, ForceMode2D.Impulse);
            StartCoroutine(DodgeReset());
           
        }
       
        if (dash > 0 && direction == "top" && dodge.dodgeBar.value == 100)
        {
            // Vector3 dir= Vector3.right - this.transform.position.x;
            _rigidibody.AddForce(Vector2.up * dodgeSpeed, ForceMode2D.Impulse);
            StartCoroutine(DodgeReset());
           
        }
       
        if (dash > 0 && direction == "bottom" && dodge.dodgeBar.value == 100)
        {
            // Vector3 dir= Vector3.right - this.transform.position.x;
            _rigidibody.AddForce(Vector2.down * dodgeSpeed, ForceMode2D.Impulse);
            StartCoroutine(DodgeReset());
           
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
           
            healthController.DamageTaken(30);
        }
        
     
       
        if (other.gameObject.CompareTag("GreenPotion"))
        {
            healthController.GainHealth(40);
            other.gameObject.SetActive(false);

        }
        if (other.gameObject.name == "gemBlue")
        {
            
            other.gameObject.SetActive(false);
            SceneManager.LoadScene("LevelCleared");

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

       if(Input.GetKey(KeyCode.Mouse1) && animOne.axe)
        {
            anim.SetInteger("AnimationType", 4);
            animOne.block = true;
            
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
     }
   public void HurtEnemy(int dmg)
    {
        enemyHealthSystem.DamageTaken(dmg);
    }
    protected virtual void AttackInMain()
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


