using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _AudioSources;
    [SerializeField] private AudioSource _AudioSources02;
    [SerializeField] private AudioClip _AClip_Bgm;
    [SerializeField] private AudioClip _AClip_Btn;
    
    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        // ΩÃ±€≈Ê ∆–≈œ
        if (Instance == null)
        {
            Instance = this;
        }

        Play();
    }

    public void Play()
    {
        _AudioSources.clip = _AClip_Bgm;
        _AudioSources.Play();
    }

    public void PlayOneShop()
    {
        _AudioSources02.PlayOneShot(_AClip_Btn);
    }
}
