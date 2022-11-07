using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class EnemyHealthSystem : MonoBehaviour
{
    public Slider healthBar;


    // Start is called before the first frame update
    void Start()
    {
        healthBar = transform.GetChild(0).GetComponent<Slider>();
        HealthReset();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
    }



    public void DamageTaken(int dmg)
    {

        healthBar.value -= dmg;

        if (healthBar.value < 0)
            healthBar.value = 0;
    }

    public void HealthReset()
    {
        healthBar.value = 100;
    }

}
