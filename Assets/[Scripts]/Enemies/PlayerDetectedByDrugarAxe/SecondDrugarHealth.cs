using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SecondDrugarHealth : MonoBehaviour
{
    public Slider healthBar;

    void Start()
    {
        healthBar = transform.GetChild(0).GetComponent<Slider>();
        HealthReset();

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
