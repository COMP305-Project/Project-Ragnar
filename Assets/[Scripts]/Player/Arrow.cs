using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
   
    private Rigidbody2D rb;
    public float force;
    PlayerController controller;
   
    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        controller = GameObject.FindObjectOfType<PlayerController>();
     
    }
    private void FixedUpdate()
    {
        if (controller.animOne.bow && !Input.GetKey(KeyCode.Mouse1) && !controller.animOne.block)
        {
            switch (controller.direction)
            {
                case "right":
                    rb.AddForce(Vector2.right * force, ForceMode2D.Impulse);
                   // transform.rotation = new Quaternion(transform.localRotation.x, transform.localRotation.y, transform.localRotation.z-90,0); 
                    break;
                case "left":
                    rb.AddForce(Vector2.left * force, ForceMode2D.Impulse);

                    break;
                case "top":
                    rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
                    break;
                case "bottom":
                    rb.AddForce(Vector2.down * force, ForceMode2D.Impulse);
                    break;
                  
            }
        }
       
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject)
        {
            Destroy(this.gameObject);
        }
    }


}
