using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector2 direction;
    public Rigidbody2D rb;
    [Range(1.0f, 20.0f)]
    public float force;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {

        Move();
    }

    public void Move()
    {
        rb.AddForce(direction * force * Time.deltaTime, ForceMode2D.Impulse);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject)
            Destroy(this.gameObject);
    }
}
