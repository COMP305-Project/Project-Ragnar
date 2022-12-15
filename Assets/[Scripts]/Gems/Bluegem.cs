using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bluegem : MonoBehaviour
{
    public static int totalGems = 0;
    private SoundManager soundManager;
    void Start()
    {
        soundManager = GameObject.FindObjectOfType<SoundManager>(); 
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name=="Player")
        {
            totalGems++;
            Debug.Log($"You have {Bluegem.totalGems} gems");
            Destroy(gameObject);
            soundManager.PlaySound(SOUND_FX.COIN);
        }
    }
}
