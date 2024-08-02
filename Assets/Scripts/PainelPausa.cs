using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PainelPausa : MonoBehaviour
{
    public  GameObject  painelPausa, botaoUm, botaoDois;

    void Start(){

        painelPausa.SetActive(false);
        botaoUm.SetActive(true);
        botaoDois.SetActive(false);
    }
    
    public void PusarJogo(){

        painelPausa.SetActive(true);
        botaoUm.SetActive(false);
        botaoDois.SetActive(true);
        Time.timeScale = 0;
        SoundManager.Instance.musicaFundo.Pause();
    }
    public void ContinuarJogo(){

        Time.timeScale = 1;
        painelPausa.SetActive(false);
        botaoUm.SetActive(true);
        botaoDois.SetActive(false);
        SoundManager.Instance.musicaFundo.UnPause();
        
    }

}
