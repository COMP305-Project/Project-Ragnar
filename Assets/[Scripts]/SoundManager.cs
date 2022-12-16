using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable] 
public  class SoundManager : MonoBehaviour
{
    public  AudioMixer mixer;
    private AudioSource audioSource;
    private List<AudioClip> clips;
    public bool soundPlayed;
   
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        clips = new List<AudioClip>();
        CreateSoundFX();
        soundPlayed = false;
       
        
    }

    void CreateSoundFX()
    {
        clips.Add(Resources.Load<AudioClip>("Audio/dash"));
        clips.Add(Resources.Load<AudioClip>("Audio/death"));
        clips.Add(Resources.Load<AudioClip>("Audio/attack"));
        clips.Add(Resources.Load<AudioClip>("Audio/hurt"));
        clips.Add(Resources.Load<AudioClip>("Audio/coin"));
        clips.Add(Resources.Load<AudioClip>("Audio/Rune"));
        clips.Add(Resources.Load<AudioClip>("Audio/health"));
        clips.Add(Resources.Load<AudioClip>("Audio/click"));
        clips.Add(Resources.Load<AudioClip>("Audio/ InGameMusic"));
        mixer = Resources.Load<AudioMixer>("Audio/MasterAudioMixer");

    }
   


   public  void PlaySound(SOUND_FX sound)
    {
        
       audioSource.clip = clips[(int)sound];
      audioSource.Play();
     
    }

    public void ChangeMasterVolume(float volume)
    {
        mixer.SetFloat("MasterVolume", volume);
    }
    public void ChangeSoundFXVolume(float volume)
    {
        mixer.SetFloat("SoundFXVolume", volume);
    }
    public void ChangeMusicVolume(float volume)
    {
        mixer.SetFloat("MusicVolume", volume);
    }

}
