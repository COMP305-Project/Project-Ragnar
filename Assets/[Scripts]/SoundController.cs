using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
   SoundManager soundManager;

   
    public void GetRef()
    {
        soundManager = GameObject.FindObjectOfType<SoundManager>();
    }

    public void PlayAttack()
    {
        soundManager.PlaySound(SOUND_FX.ATTACK);
    }

    public void PlayDeath()=> soundManager.PlaySound(SOUND_FX.DEATH);

    public void PlayRune() => soundManager.PlaySound(SOUND_FX.Rune);
}
