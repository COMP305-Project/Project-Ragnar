using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLevelThree : MonoBehaviour
{
    AudioSource clip;

    private void Start()
    {
        clip = GetComponent<AudioSource>();
        clip.Play();
        
    }
}
