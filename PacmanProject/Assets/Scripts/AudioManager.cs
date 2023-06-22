using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; set; }

    public AudioClip confettiClip;
    
    public AudioClip startGameClip;
    
    public AudioClip finishGameClip;
    
    public AudioClip eatClip;

    private AudioSource audioSource;

    private void Awake()
    {
        Instance = this;

        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        PlayClip(startGameClip);
    }

    public void PlayClip(AudioClip clip)
    {
        audioSource.clip = clip;
        
        audioSource.Play();
    }
}
