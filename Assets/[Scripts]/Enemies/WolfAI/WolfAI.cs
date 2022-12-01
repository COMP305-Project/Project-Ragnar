using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class WolfAI : MonoBehaviour
{
    [Header("WolfBrain")]

    public Transform aheadCheck;
    public Transform center;

    [Header("Movement Properties")]
    public float speed = 4f;
   public Vector3 direction;

    [Header("Attack style")]
    Rigidbody2D rb;
    public Vector2 force;
    public float forceSpeed = 2f;
    public bool check;


    public LayerMask wall;
    public float radius;
    private WolfAiDetection detected;
    private PlayerController player;
    public float chaseSpeed = 6f;

    public float time;
    public Vector2 attack;
    public bool hurtPlayer;
    public EnemyHealthSystem healthValue;
    private void Start()
    {
        direction = Vector2.up;
        detected = FindObjectOfType<WolfAiDetection>();
        player = FindObjectOfType<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        healthValue = FindObjectOfType<EnemyHealthSystem>();
      
        
    }

    private void Update()
    {
        var wallAhead = Physics2D.Linecast(center.position, aheadCheck.position, wall);

        attack = (player.transform.position - transform.position).normalized;   

        if (wallAhead)
            Flip();
        if (detected.los)
        {
            Chase();
            
        }
          
        WolfDeath();
        Movement();
    }
    void Movement()
    {
        transform.position += new Vector3(0.0f, direction.y * speed * Time.deltaTime, 0f);
    }
    
     IEnumerator AttackReset()
    {
        yield return new WaitForSeconds(time);
        rb.velocity = Vector3.zero;
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(center.position, radius);
    }
    void Flip()
    {
        transform.localScale = new Vector3(1, transform.localScale.y * -1, 1);
        direction *= -1;
    }
    void Chase()
    {
        rb.AddForce(attack * forceSpeed * Time.deltaTime, ForceMode2D.Impulse);
        StartCoroutine(AttackReset());
        hurtPlayer = true;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name =="Player" && player.attack )
        {
            Invoke("HurtMe", 0.5f);
        }
        if(other.gameObject.name =="Player" && hurtPlayer )
        {
            if (player.animOne.block)
                player.HurtPlayer(5);
            else
                player.HurtPlayer(40);
        }
    }
    void HurtMe()
    {
        player.HurtEnemy(20);
    }
    void WolfDeath()
    {
        if (healthValue.healthBar.value <= 0)
            this.gameObject.SetActive(false);
    }
}
