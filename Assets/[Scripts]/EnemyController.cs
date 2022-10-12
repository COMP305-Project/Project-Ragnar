using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform _player;
    [Range(800,1200)]
    public float rSpeed = 800f;

    public float _minDistance;
    public float chaseSpeed = 0.5f;
    Rigidbody rb;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         Vector3 direction = transform.position - _player.position;
        var vel = Vector2.Distance(transform.position,_player.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        direction.Normalize();
        if(vel < _minDistance)
            transform.Translate(direction*Time.deltaTime*chaseSpeed);
       
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation,rotation, Time.deltaTime  * rSpeed);
      
    }

   

}
