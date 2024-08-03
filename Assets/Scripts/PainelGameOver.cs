using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PainelGameOver : MonoBehaviour
{
    public void Reiniciar(){

        SortearFase();
        SoundManager.Instance.somLaserPlayer.Play();
    }

    public void VoltarInicio(){

        SceneManager.LoadScene("Menu");
        SoundManager.Instance.somLaserPlayer.Play();
    }

    public void Sair(){

        Application.Quit();
        SoundManager.Instance.somLaserPlayer.Play();
        Debug.Log("Saiu");
    }

    void SortearFase(){

        int escolherFase = Random.Range(0, 4);

        switch(escolherFase){

            case 0:
            SceneManager.LoadScene("Fase1");
            break;

            case 1:
            SceneManager.LoadScene("Fase2");
            break;

            case 2:
            SceneManager.LoadScene("Fase3");
            break;
        }
    }
}
