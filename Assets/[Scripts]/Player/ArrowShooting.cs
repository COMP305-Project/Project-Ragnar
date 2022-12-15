using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShooting : MonoBehaviour
{
    
 
    public GameObject arrow;
    public Transform arrowTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;

    public PlayerController playerController;
    void Start()
    {
       
        playerController = GameObject.FindObjectOfType<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerController.animOne.bow)
            Fire();
    }

   

    public void Fire()
    {
        if(!canFire)
        {
            timer += Time.deltaTime;
            if(timer>timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }
        if(Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            Instantiate(arrow,arrowTransform.position,Quaternion.identity);
        }
    }

   
}
