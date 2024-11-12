using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioClips
{
    ak47Gunshot 
}


public class AudioManager : MonoBehaviour
{
    public List<AudioClip> clipList;

    public AudioClip currentClip = null; 

    public AudioSource audioSource;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ChangeClip(AudioClips clip)
    {
        audioSource.clip = clipList[(int)clip]; 
    }

    public void PlayAudioClip()
    {
        audioSource.Play(); 
    }
}
