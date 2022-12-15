using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDetectsPlayer : MonoBehaviour
{
    [Header("Sensing suite")]
    public bool los;
    public bool playerDetected;
    public float radiusDetection;

    private Transform player;
    public LayerMask playerMask;
    public Collider2D colliderName;

    public Vector2 playerDirection;
    public float enemyDirectionValue;
    public float playerDirectionValue;
    // Start is called before the first frame update
    void Start()
    {
        playerDirectionValue = 0;
        enemyDirectionValue = 0;
        playerDirection = Vector2.zero;
        los = false;
        playerDetected = false;
        player = FindObjectOfType<PlayerController>().transform;


    }

    // Update is called once per frame
    void Update()
    {
        if (playerDetected)
            CreateLOS();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
            playerDetected = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
            playerDetected = false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = (los) ? Color.green : Color.red;
        if (playerDetected)
        {
            Gizmos.DrawLine(transform.position, player.position);
        }

        Gizmos.color = (playerDetected) ? Color.green : Color.red;
        Gizmos.DrawWireSphere(transform.position, 5.0f);
    }
    void CreateLOS()
    {
        var lineCreate = Physics2D.Linecast(transform.position, player.position, playerMask);
        colliderName = lineCreate.collider;
        playerDirection = player.position - transform.position;
        playerDirection.Normalize();
        playerDirectionValue = (playerDirection.x < 0) ? -1.0f : 1.0f;
        enemyDirectionValue = GetComponentInParent<BossMovement>().direction.x;
        los = (lineCreate.collider.gameObject.name == "Player") && (playerDirectionValue == enemyDirectionValue);
    }
}
