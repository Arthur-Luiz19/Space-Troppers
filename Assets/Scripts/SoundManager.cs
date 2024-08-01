using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    
    public AudioSource somExplosão, SomLaserInimigo, somLaserPlayer;

    void Awake()
    {
        Instance = this;
    }

    
    void Update()
    {
        
    }
}
