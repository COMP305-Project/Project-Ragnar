using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _speed;
    public float _force;
    public bool iFrames = false;
    Rigidbody2D _rigidibody;

    public int HP = 100;


    // Start is called before the first frame update
    void Start()
    {
        _rigidibody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (HP > 0)
            Movement();
    }
    
      public float xM(float x)
    {
        x = Input.GetAxisRaw("Horizontal");
        if (x > 0.0f || x< 0.0f)
          transform.localScale = new Vector3(1.5f, 0.3f, 0.0f);
        return x;
    }
    public float yM(float y)
    {
        y = Input.GetAxisRaw("Vertical");
        if (y > 0.0f || y < 0.0f)
            transform.localScale = new Vector3(0.5f, 1f, 0.0f);
        return y;
    }

    private void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (x != 0.0f)
        {
            transform.position += new Vector3(xM(x), 0.0f, 0.0f) * Time.deltaTime * _speed;

        }

        if (y != 0.0f)
            transform.position += new Vector3(0.0f, yM(y), 0.0f) * Time.deltaTime * _speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        HurtPlayer(other);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        HurtPlayer(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        HurtPlayer(other);
    }

    //a method for detecting if the trigger is enabled on top of the player is necessary. right now, it only gets called when the player moves, then stops working until the player moves again

    private void HurtPlayer(Collider2D other)
    {
        Debug.Log("collision");
        if (!iFrames)
        {
            if (other.enabled)
            {
                iFrames = true;
                HP -= other.GetComponent<Attack>().damage;
            }
        }

        if (HP <= 0)
        {
            Debug.Log("You died!"); //more touchups are obviously needed, but this will do for now
        }
    }
}
