using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InitialPoint : MonoBehaviour
{
    public Transform attackPoint;
    public Vector2 position;
    public string state;
    public decimal stateTwo;
    Vector2 direction;
    public float speed;
  
    void Start()
    { 
       attackPoint = GameObject.Find("AttackPoint").GetComponent<Transform>();
        position = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        state = direction.x.ToString();
       
        direction = attackPoint.position - transform.position;
        direction.Normalize();

        transform.position += new Vector3(direction.x * speed * Time.deltaTime,0f,0f);
       

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
      //  Gizmos.DrawLine(attackPoint.position, this.transform.position);
        Gizmos.DrawRay(transform.position,direction);
    }
}
