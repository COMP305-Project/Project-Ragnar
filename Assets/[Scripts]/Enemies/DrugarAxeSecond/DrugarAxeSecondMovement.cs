using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugarAxeSecondMovement : MonoBehaviour
{
    [Header("DrugarBrain")]

    public Transform aheadCheck;
    public Transform center;

    [Header("Movement Properties")]
    public float speed = 4f;
    public Vector3 direction;

    [Header("Attack style")]
    Rigidbody2D rb;
    public Vector2 force;
  
    public bool check;


    public LayerMask wall;
    public float radius;
    private SecondDrugarDetection detected;
    private PlayerController player;
    public float chaseSpeed = 6f;
    public SecondDrugarHealth healthValue;
    public float time;
    public Vector2 attack;
    public bool hurtPlayer;

    private Animator anim;

    private void Start()
    {
        direction = Vector2.left;
        detected = FindObjectOfType<SecondDrugarDetection>();
        player = FindObjectOfType<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        healthValue = FindObjectOfType<SecondDrugarHealth>();
        anim = GetComponent<Animator>();

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
        else
            Movement();

        DrugarDeath();

    }
    void Movement()
    {
        transform.position += new Vector3(direction.x * speed * Time.deltaTime, 0f, 0f);
    }

    IEnumerator AttackReset()
    {
        yield return new WaitForSeconds(time);
        hurtPlayer = false;

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
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, chaseSpeed * Time.deltaTime);
        // StartCoroutine(AttackReset());
        hurtPlayer = true;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player" && player.attack)
        {
            Invoke("HurtMe", 0.5f);
        }

    }
    private void OnCollisionStay2D(Collision2D other)
    {
        StartCoroutine(AttackReset());
        if (other.gameObject.name == "Player" && hurtPlayer)
        {

            anim.SetInteger("AnimationState", 1);
            Invoke("AttackPlayer", 1);

        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            anim.SetInteger("AnimationState", 0);

        }
    }
    void HurtMe()
    {
        healthValue.DamageTaken(60);
    }
    void DrugarDeath()
    {
        if (healthValue.healthBar.value <= 0)
            this.gameObject.SetActive(false);
    }
    void AttackPlayer()
    {
        if (player.animOne.block)
            player.HurtPlayer(0);
        else
            player.HurtPlayer(1);
    }
}
