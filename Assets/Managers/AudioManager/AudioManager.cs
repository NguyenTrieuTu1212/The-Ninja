using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Sound[] musicSound;
    [SerializeField] private Sound[] sfxSound;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;


    private static AudioManager instance;
    public static AudioManager Instance => instance;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }



    private void Start()
    {
        PlayMusic("Theme");
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSound, x => x.nameClip == name);
        if (s == null) return;
        musicSource.clip = s.clip;
        musicSource.Play();
    }



    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSound, x => x.nameClip == name);
        if(s== null) return;
        sfxSource.PlayOneShot(s.clip);
    }
}
