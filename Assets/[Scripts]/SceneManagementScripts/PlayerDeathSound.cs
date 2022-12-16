using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathSound : SoundController
{ 
    // Start is called before the first frame update
    void Start()
    {
        GetRef();
        PlayDeath();
    }

    // Update is called once per frame
  
}
