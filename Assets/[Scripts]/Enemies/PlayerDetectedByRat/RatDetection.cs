using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatDetection : MonoBehaviour
{
    public bool detectPlayer;
    public bool los;

    private PlayerController player;
    public LayerMask playerMask;
    private Collider2D colliderName;
  
    private Vector2 playerDirection;
    public float playerDirectionValue;
    public float enemyDirectionValue;
    void Start()
    {
        los = false;
        detectPlayer = false;
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (detectPlayer)
            createLOS();
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            detectPlayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            detectPlayer = false;
        }
    }

    void createLOS()
    {
        var check = Physics2D.Linecast(transform.position, player.transform.position, playerMask);
        colliderName = check.collider;
        playerDirection = player.transform.position - transform.position;
        playerDirection.Normalize();
        playerDirectionValue = (playerDirection.x > 0) ? 1f : -1f;
        enemyDirectionValue = GetComponentInParent<RatMovement>().direction.x;

        los = (check.collider.name == "Player") && (playerDirectionValue == enemyDirectionValue);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = (los) ? Color.yellow : Color.magenta;
        if (detectPlayer)
        {
            Gizmos.DrawLine(transform.position, player.transform.position);
        }

        Gizmos.color = (detectPlayer) ? Color.green : Color.red;
        Gizmos.DrawWireSphere(transform.position, 6.0f);
    }
}
