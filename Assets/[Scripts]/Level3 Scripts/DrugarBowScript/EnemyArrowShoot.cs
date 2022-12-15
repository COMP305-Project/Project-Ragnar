using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrowShoot : MonoBehaviour
{
    public GameObject arrow;
    public Transform arrowTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    public Vector2 targetOffest;

    public DetectionDrugerBow detect;
    void Start()
    {

        detect = GameObject.FindObjectOfType<DetectionDrugerBow>();

    }

    // Update is called once per frame
    void Update()
    {
        if (detect.los)
        {
            Fire();
            Debug.Log("Arrow fired");
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
            var ar = Instantiate(arrow, arrowTransform.position,Quaternion.identity);
            ar.GetComponent<EnemyArrow>().direction = detect.playerDirection;
        }
    }

}
