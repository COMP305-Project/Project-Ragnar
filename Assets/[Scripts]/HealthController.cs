using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class HealthController : MonoBehaviour
{
    public Slider healthBar;
   
    
    // Start is called before the first frame update
    void Start()
    {
        healthBar = transform.GetChild(1).GetComponent<Slider>();
        HealthReset();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Death();
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
    private void Death()
    {
        if (healthBar.value==0)
        {
            SceneManager.LoadScene("DeathScene");
        }
    }
    public void GainHealth(int hlt)
    {
        healthBar.value += hlt;
        if (healthBar.value > 100)
            healthBar.value = 100;
           
    }

}
