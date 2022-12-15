using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform _player;
    [Range(800,1200)]
    public float rSpeed = 800f;

    public float _minDistance = 1.5f;
    public float chaseSpeed = 5f;
    Rigidbody rb;
    public float telegraph = 1f;
    public float buffer = 3f;
    public bool isAttacking = false;
    public bool canAttack = false;
    public bool showBox = false;
    EnemyHealthSystem healthSystem;
    public int damage = 25;
    
    public PlayerController playerController;
    //Checking if player within the radius
    public bool isClose;

    public LayerMask playerMask;
    
    public int radius;

    private Vector3 originalPosition;



    void Start()
    {
        rb = this.GetComponent<Rigidbody>();

        originalPosition = transform.position;
        healthSystem = GetComponent<EnemyHealthSystem>();   
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var vel = Vector2.Distance(transform.position, _player.position);
        //Debug.Log(vel);
        if (!showBox)
        {
            if (vel < _minDistance)
            {
                if (canAttack)
                    isAttacking = true;
                while (isAttacking)
                {
                    if (telegraph > 0)
                    {
                        //some sort of deceleration code goes here
                        telegraph -= Time.deltaTime;
                    }
                    else
                    {
                        Debug.Log("attacking");
                        telegraph = 1f;
                        this.GetComponent<GlobalTimer>().attackBuffer = buffer;
                        isAttacking = false;
                        showBox = true;

                       
                        this.GetComponent<GlobalTimer>().boxTimer = 0.5f;
                    }
                }
            }
            
        }
        
          
       


    }

   
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, radius);
    }
    

    

}
