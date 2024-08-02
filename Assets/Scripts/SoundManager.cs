using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    
    public AudioSource somExplosão, SomLaserInimigo, somLaserPlayer, musicaFundo;

    void Awake()
    {
        Instance = this;
        musicaFundo.Play();
    }

    
    void Update()
    {
        
    }
}
