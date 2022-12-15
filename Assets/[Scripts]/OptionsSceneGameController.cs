using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsSceneGameController : MonoBehaviour
{
    public  Slider masterVolumeSlider;
    public  Slider soundSlider;
    public  Slider musicSlider;
    public SoundManager soundManager;
    void Start()
    {
        masterVolumeSlider = GameObject.Find("MasterSlider").GetComponent<Slider>();
        soundSlider = GameObject.Find("SoundFxSlider").GetComponent<Slider>();
        musicSlider = GameObject.Find("MusicSlider").GetComponent <Slider>();
        soundManager = GameObject.FindObjectOfType<SoundManager>();

       
        soundManager.mixer.GetFloat("MasterVolume", out var Mastervolume);
        masterVolumeSlider.value = Mastervolume;
        soundManager.mixer.GetFloat("SoundFXVolume", out var soundvolume);
        soundSlider.value = soundvolume;
        soundManager.mixer.GetFloat("MusicVolume", out var musicvolume);
        musicSlider.value = musicvolume;
    }

  
}
