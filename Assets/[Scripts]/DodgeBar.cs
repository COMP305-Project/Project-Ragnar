using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class DodgeBar : MonoBehaviour
{

    public Slider dodgeBar;
    public PlayerController playerController;
    void Start()
    {
        dodgeBar = transform.GetChild(1).GetComponent<Slider>();
        playerController = FindObjectOfType<PlayerController>();

        StaminaReset();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        StaminaZero();
        RegainStamina();
    }

    public void StaminaReset()
    {
        dodgeBar.value = 100;
    }
    private void StaminaZero()
    {
        if (playerController.dashPerformed)
            dodgeBar.value = 0;
    }
    private void RegainStamina()
    {
        if (dodgeBar.value < 100)
        {
            dodgeBar.value +=1;
        }
        if (dodgeBar.value > 100)
            dodgeBar.value = 100;

    }
}
