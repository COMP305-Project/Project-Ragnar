using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatMovement : SoundController
{

    public Transform aheadCheck;
    public Transform center;
    public float radius;
    public float speed = 5f;

    public LayerMask wall;
    public Vector2 direction;
    private PlayerController player;
   
    private RatHealth health;
    public bool ratDeath;
    public int damageTaken;
    void Start()
    {
        direction = Vector2.left;
        player = FindObjectOfType<PlayerController>();
      
        health = FindObjectOfType<RatHealth>();
        ratDeath = false;
        GetRef();
    }

    // Update is called once per frame
    void Update()
    {
        var isWallAhead = Physics2D.Linecast(center.position, aheadCheck.position, wall);
        if (isWallAhead)
            Flip();
        Movement();
        RatDeath();
    }
    void Movement()
    {
        transform.position += new Vector3(direction.x * speed * Time.deltaTime, 0f,0f);
    }

    void Flip()
    {
        transform.localScale = new Vector3(1f, transform.localScale.y * -1f, 1f);
        direction *= -1f;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(center.position, radius);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name=="Player")
        {
            
            if (player.animOne.block)
                player.HurtPlayer(1);
            else
                player.HurtPlayer(10);
        }
        if (other.gameObject.CompareTag("Arrow"))
        {
            PlayAttack();
            health.DamageTaken(20);

        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.name == "Player" && player.attack)
        {
            Invoke("HurtMe", 0.5f);
        }
    }
    void HurtMe()
    {
        if (player.animOne.sword && player.timer >= 27)
        {
            health.DamageTaken(damageTaken);
            Debug.Log(damageTaken);
            PlayAttack();
        }

        else if (player.animOne.axe && player.timer >= 27)
        {
            health.DamageTaken(10);
            PlayAttack();
        }
       


        }
   public  void RatDeath()
    {
        if (health.healthBar.value == 0)
        {
            Destroy(this.gameObject);
            ratDeath = true;
        }
           
       
    }
}
