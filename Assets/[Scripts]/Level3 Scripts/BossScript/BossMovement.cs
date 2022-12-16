using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : SoundController
{
    public Transform aheadCheck;
    public Transform center;
    public float speed = 3f;
    public LayerMask wall;
    public float radius;
    public int dmg;
    public Vector3 direction;
    BossHealth health;
    public bool hurtPlayer;
    private PlayerController player;
    private BossDetectsPlayer detected;
    private Vector3 lookDirection;
    private Rigidbody2D rb;

   
    public GameObject rune;
    void Start()
    {
        direction = Vector2.left;
        detected = FindObjectOfType<BossDetectsPlayer>();
        health = FindObjectOfType<BossHealth>();
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

           
            transform.rotation = Quaternion.AngleAxis(90f , Vector3.forward);
            Movement();
        }

        else
        {
            StandBy();
            LookAtPlayer();
        }
        BossDeath();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player" && player.attack)
        {
            Invoke("HurtMe", 0.5f);
        }
       
       
    }
    void Movement()
    {
        transform.position += new Vector3(direction.x * speed * Time.deltaTime,0f , 0f);
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
            health.DamageTaken(5);
            PlayAttack();
        }
       
    }
    void BossDeath()
    {
        if (health.healthBar.value <= 0)
        {
            rune.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
            

        
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
            if (lookDirection != Vector3.zero)
            {
                float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle -90f, Vector3.forward);
            }
        }
    }

    public void StandBy()
    {
        rb.velocity = Vector3.zero;
    }
}
