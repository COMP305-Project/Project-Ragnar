using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform _player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = _player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.Translate(direction*Time.deltaTime);
       // Quaternion angleAxis = Quaternion.AngleAxis(angle, Vector3.forward);
       // transform.eulerAngles = Vector3.forward * angle - 90;
    }
}
