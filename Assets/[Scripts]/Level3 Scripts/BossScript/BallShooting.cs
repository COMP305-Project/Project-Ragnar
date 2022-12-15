using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooting : MonoBehaviour
{
    public GameObject ball;
    public Transform ballTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    public Vector2 targetOffest;

    public BossDetectsPlayer detect;
    void Start()
    {

        detect = GameObject.FindObjectOfType<BossDetectsPlayer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (detect.playerDetected)
        {
            Fire();
            Debug.Log("Ball fired");
        }
          
    }



    public void Fire()
    {
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }
        if (canFire)
        {
            canFire = false;
            var ar = Instantiate(ball, ballTransform.position, Quaternion.identity);
            ar.GetComponent<Ball>().direction = detect.playerDirection;
        }
    }
}
