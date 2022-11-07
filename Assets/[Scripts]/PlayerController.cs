using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[System.Serializable]
public class PlayerController : MonoBehaviour
{
    public float _speed;
    public float _force;
    public bool iFrames = false;
    Rigidbody2D _rigidibody;
    public int dmgCount;
    public bool startChase;
    public bool endChase;   
    public HealthController healthController;
    public EnemyHealthSystem enemyHealthSystem;
    public bool attack;
    public int radius;
    public float dashSpeed =1f;
    Animator anim;
    public GameObject gem;
    public GameObject enemy;
    Attack attck;

    // Start is called before the first frame update
    void Start()
    {
        _rigidibody = GetComponent<Rigidbody2D>();
        healthController = GameObject.Find("PlayerHealthSystem").GetComponent<HealthController>();
        anim = GetComponent<Animator>();
        enemyHealthSystem = FindObjectOfType<EnemyHealthSystem>();
        attck=GetComponent<Attack>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        Movement();
        Attack();
       
       
       
    }
    
      public float xM(float x)
    {
        
        if (x > 0.0f)
        {
           transform.localRotation = Quaternion.Euler(0.0f, 0.0f, -90.0f);
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
            transform.localScale = new Vector2(1, 1);
        }
            

        return x;
    }
    public float yM(float y)
    {
     
        if (y > 0.0f)
        {
            transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            transform.localScale = new Vector2(1, 1);
        }
            
        else
        {
            transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            transform.localScale = new Vector2(1, -1);
        }
           
        return y;
    }

    private void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        bool dash = Input.GetKey(KeyCode.Space);
     

        if (x != 0.0f)
        {
            transform.position += new Vector3(xM(x), 0.0f, 0.0f) * Time.deltaTime * _speed;
            anim.SetInteger("AnimationType", 1);
         

        }
        else
        {
            anim.SetInteger("AnimationType", 0);
          
        }
        if (dash)
            _rigidibody.AddForce(Vector3.right);

        if (y != 0.0f)
        {
            transform.position += new Vector3(0.0f, yM(y), 0.0f) * Time.deltaTime * _speed;
            anim.SetInteger("AnimationType", 1);
           
        }
        else
            anim.SetInteger("AnimationType", 0);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Spike"))
        {
           
            healthController.DamageTaken(30);
        }
        switch (other.gameObject.name)
        {
            case "Melee":HurtPlayer(10);
                break;
            case "Melee1":HurtPlayer(30);
                break;
            case "Melee2":HurtPlayer(50);
                break;
        }

        if (
            other.gameObject.name == "TriggerPoint" || 
            other.gameObject.name == "TriggerPoint1" 
            || other.gameObject.name == "TriggerPoint2")
        {
            startChase = true;
            endChase = false;
        }
        else
        {
            startChase = false;
            endChase = true;
        }
        if (other.gameObject.CompareTag("Enemy") && attack)
        {
            HurtEnemy(10);
            if (enemyHealthSystem.healthBar.value == 0)
            {
                enemy.SetActive(false);
              
                gem.SetActive(true);
               // gem.transform.position = other.transform.position;
            }
                
        }
        if (other.gameObject.name == "potionGreen")
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



    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "TriggerPoint" ||
            other.gameObject.name == "TriggerPoint1"
            || other.gameObject.name == "TriggerPoint2")
        {
            startChase = true;
            endChase = false;
        }
        else
        {
            startChase = false;
            endChase = true;
        }
      
      

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "TriggerPoint" ||
            other.gameObject.name == "TriggerPoint1"
            || other.gameObject.name == "TriggerPoint2")
        {
            startChase = false;
            endChase = true;
        }
        else
        {
            startChase = true;
            endChase = false;
        }
    }

    private void Attack()
    {
        float fire = Input.GetAxisRaw("Fire1");
        if (fire > 0.0)
        {
            anim.SetInteger("AnimationType", 2);
            attack = true;
        }
        else
        {
            attack = false;
        }
 }

   

    //a method for detecting if the trigger is enabled on top of the player is necessary. right now, it only gets called when the player moves, then stops working until the player moves again

    private void HurtPlayer(int dmg)
    {      
                healthController.DamageTaken(dmg);
     }
   private void HurtEnemy(int dmg)
    {
        enemyHealthSystem.DamageTaken(dmg);
    }
   
}
