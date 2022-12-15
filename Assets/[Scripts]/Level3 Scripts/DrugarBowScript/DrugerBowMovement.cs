using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugerBowMovement : SoundController
{
    public Transform aheadCheck;
    public Transform center; 
    public float speed = 3f;
    public LayerMask wall;
    public float radius;
    public int dmg;
   public  Vector3 direction;
    DrugerBowHealth health;
    public bool hurtPlayer;
    private PlayerController player;
    private DetectionDrugerBow detected;
    private Rigidbody2D rb;
    Vector3 lookDirection;
    void Start()
    {
        direction = Vector2.up;
         detected = FindObjectOfType<DetectionDrugerBow>();
         health= FindObjectOfType<DrugerBowHealth>();
       player = FindObjectOfType<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        GetRef();
    }

    // Update is called once per frame
    void Update()
    {
        var wallAhead = Physics2D.Linecast(center.position, aheadCheck.position, wall);

        

        if (wallAhead)
            Flip();

        if (!detected.playerDetected)
        {
            transform.rotation = Quaternion.identity;
            Movement();
        }
            
        else
        {
            StandBy();
            LookAtPlayer();
        }
            
        DrugerDeath();
       
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player" && player.attack)
        {
            Invoke("HurtMe", 0.5f);
        }
        if (other.gameObject.name == "Player" && hurtPlayer)
        {
            if (player.animOne.block)
                player.HurtPlayer(5);
            else
                player.HurtPlayer(40);
        }
        if (other.gameObject.CompareTag("Arrow"))
        {
            health.DamageTaken(10);
            PlayAttack();
        }
    }
    void Movement()
    {
        transform.position += new Vector3(0.0f, direction.y * speed * Time.deltaTime, 0f);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(center.position, radius);
    }
    void HurtMe()
    {
        if (player.animOne.sword)
        {
            health.DamageTaken(dmg);
            PlayAttack();
        }
        if (player.animOne.axe)
        {
            health.DamageTaken(30);
            PlayAttack();
        }
       
    }
    void DrugerDeath()
    {
        if (health.healthBar.value <= 0)
            this.gameObject.SetActive(false);
    }
    void Flip()
    {
        transform.localScale = new Vector3(1, transform.localScale.y * -1, 1);
        direction *= -1;
    }

   public void LookAtPlayer()
    {
        if (detected.playerDetected)
        {
            lookDirection = player.transform.position - transform.position;
            if(lookDirection!=Vector3.zero)
            {
                float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle + 90f, Vector3.forward);
            }
        }
    }

    public void StandBy()
    {
        rb.velocity = Vector3.zero;
    }
}
