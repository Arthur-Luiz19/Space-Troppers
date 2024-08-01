using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Pontuação")]
    public int Pontuacao;
    public TMP_Text txtPontuacao;

    [Header("Tela Game Over")]
    public GameObject painelGameOver;
    public TMP_Text pontuacaoFinal;
    public TMP_Text highScore;
    public AudioSource musicaFundo;
    public AudioSource musicaGameOver;
    
    void Awake(){

        Instance = this;
    }
    
    void Start()
    {
        Pontuacao = 0;
        musicaFundo.Play();
        Time.timeScale = 1;

        txtPontuacao.text = "Score: " + Pontuacao;
        painelGameOver.SetActive(false);
    }

    
    void Update()
    {
        
    }

    public void AumentarPontuacao(int pontosParaGanhar){

        Pontuacao += pontosParaGanhar;
        txtPontuacao.text = "Score: " + Pontuacao;
    }

    public void AtivarGameOver(){

        Time.timeScale = 0;
        musicaFundo.Stop();
        musicaGameOver.Play();

        painelGameOver.SetActive(true);
        pontuacaoFinal.text = "Pontuação: " + Pontuacao;

        if(Pontuacao > PlayerPrefs.GetInt("HighScore")){

            PlayerPrefs.SetInt("HighScore", Pontuacao);
        }

        highScore.text = "HighScore: " + PlayerPrefs.GetInt("HighScore");
    }
}
