using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _speed;
    public float _force;
    Rigidbody2D _rigidibody;



    // Start is called before the first frame update
    void Start()
    {
        _rigidibody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    public void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal") ;
        float y = Input.GetAxisRaw("Vertical") ;
       
        if (x != 0.0f)
            transform.position += new Vector3((x>0) ? 1.0f:-1.0f, 0.0f, 0.0f) * Time.deltaTime*  _speed;
       if (y != 0.0f)
            transform.position += new Vector3 (0.0f, (y > 0) ? 1.0f : -1.0f, 0.0f) * Time.deltaTime * _speed;

    }
}
