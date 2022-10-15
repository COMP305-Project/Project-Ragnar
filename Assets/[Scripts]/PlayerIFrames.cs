using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIFrames : MonoBehaviour
{

    public float iFrameTick = 0f;
    public float iFrameTime = 0f;
    public bool playerIsRed = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.GetComponent<PlayerController>().iFrames)
        {
            if (iFrameTick > 0)
            {
                Debug.Log("time start");
                iFrameTick -= Time.deltaTime;
            }
            else
            {
                Debug.Log("time end");
                if (playerIsRed)
                {
                    this.GetComponent<SpriteRenderer>().material.color = new Color(255f, 255f, 255f);
                    playerIsRed = false;
                    Debug.Log("white");
                }
                else
                {
                    this.GetComponent<SpriteRenderer>().material.color = new Color(255f, 0f, 0f);
                    playerIsRed = true;
                    Debug.Log("red");
                }
                iFrameTick = 0.1f;
                iFrameTime += 0.5f;
            }
            if (iFrameTime >= 5)
            {
                iFrameTime = 0f;
                iFrameTick = 0f;
                this.GetComponent<PlayerController>().iFrames = false;
                this.GetComponent<SpriteRenderer>().material.color = new Color(255f, 255f, 255f);
            }
        }
    }
}
