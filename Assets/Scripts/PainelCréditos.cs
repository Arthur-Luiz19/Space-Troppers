using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainelCréditos : MonoBehaviour
{
    public GameObject painelCreditos;
    void Start()
    {
        painelCreditos.SetActive(false);
        SoundManager.Instance.musicaFundo.Play();
    }

    public void MenuCreditos(){

        painelCreditos.SetActive(true);
        SoundManager.Instance.somLaserPlayer.Play();
    }

    public void FecharCreditos(){

        painelCreditos.SetActive(false);
        SoundManager.Instance.somLaserPlayer.Play();
    }

    
}
