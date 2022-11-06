using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _speed;
    public float _force;
    public bool iFrames = false;
    Rigidbody2D _rigidibody;
    private int hp=100;
    public HealthController healthController;

    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        _rigidibody = GetComponent<Rigidbody2D>();
        healthController = FindObjectOfType<HealthController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hp > 0)
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
       
     

        if (x != 0.0f)
        {
            transform.position += new Vector3(xM(x), 0.0f, 0.0f) * Time.deltaTime * _speed;
            anim.SetInteger("AnimationType", 1);
          

        }
        else
        {
            anim.SetInteger("AnimationType", 0);
          
        }
            

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
       
    }

    private void Attack()
    {
        float fire = Input.GetAxisRaw("Fire1");
        if (fire > 0.0)
        {
            anim.SetInteger("AnimationType", 2);
            

        }
 }

    private void OnTriggerStay2D(Collider2D other)
    {
        HurtPlayer(other);

    }

    private void OnTriggerExit2D(Collider2D other)
    {
         HurtPlayer(other);
    }

    //a method for detecting if the trigger is enabled on top of the player is necessary. right now, it only gets called when the player moves, then stops working until the player moves again

    private void HurtPlayer(Collider2D other)
    {
        Debug.Log("collision");
        if (!iFrames)
        {
            if (other.enabled)
            {
                iFrames = true;
                hp -= other.GetComponent<Attack>().damage;
            }
        }

        if (hp <= 0)
        {
            Debug.Log("You died!"); //more touchups are obviously needed, but this will do for now
        }
    }

}
