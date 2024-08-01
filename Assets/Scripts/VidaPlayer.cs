using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaPlayer : MonoBehaviour
{
    [Header("Vida do jogador")]
    public  int                 vidaMaxPlayer;
    private int                 vidaAtualPlayer;
    public  Slider              barraDeVidaPlayer;
    
    [Header("Escudo do jogador")]
    public  bool                temEscudo;
    public  GameObject          Escudo;
    public  float               tempoMaxEscudo;
    public  float               tempoAtualEscudo;
    public  Slider              BarraDeVidaEscudo;

    [Header("Scripts")]
    public  PlayerController    player;
    private ItensColecionaveis  itensColecionaveis;

    [Header("Efeito explosão")]
    public  GameObject          efeitoExplosao;
    
    void Start()
    {
        GetComponent<PlayerController>();
        GetComponent<ItensColecionaveis>();
        
        vidaAtualPlayer = vidaMaxPlayer;
        barraDeVidaPlayer.maxValue = vidaMaxPlayer;
        barraDeVidaPlayer.value = vidaAtualPlayer;
        BarraDeVidaEscudo.gameObject.SetActive(false);

        Escudo.SetActive(false);
        temEscudo = false;
    }

    void Update()
    {
        if(temEscudo){

            CronometroEscudo();
        }
    }

    public void AtivarEscudo(){

        BarraDeVidaEscudo.gameObject.SetActive(true);
        
        tempoAtualEscudo = tempoMaxEscudo;
        BarraDeVidaEscudo.maxValue = tempoMaxEscudo;
        BarraDeVidaEscudo.value = tempoAtualEscudo;
        Escudo.SetActive(true);
        temEscudo = true;
        
    }

    public void GanharVida(int receberVida){

        if(vidaAtualPlayer + receberVida <= vidaMaxPlayer){

            vidaAtualPlayer += receberVida;
        }
        else{
            vidaAtualPlayer = vidaMaxPlayer;
        }

        barraDeVidaPlayer.value = vidaAtualPlayer;
    }

    public void DanoPlayer(int levarDano){

        if(temEscudo == false){

            SoundManager.Instance.SomLaserInimigo.Play();
            vidaAtualPlayer -= levarDano;
            barraDeVidaPlayer.value = vidaAtualPlayer;


            if(player.laserDuplo){
                player.laserDuplo = false;
                ItensColecionaveis.numUpgrade--;
            }
            if(player.laserTriplo){
                player.laserTriplo = false;
                player.laserDuplo = true;
                ItensColecionaveis.numUpgrade--;
            }

            if(vidaAtualPlayer <= 0){

                Debug.Log("Game Over!");
                Instantiate(efeitoExplosao, transform.position, transform.rotation);
                GameManager.Instance.AtivarGameOver();
                SoundManager.Instance.somExplosão.Play();
                vidaAtualPlayer = 0;
                PlayerController.Instance.estaVivo = false;
            }
        }
        //else{

            //vidaAtualEscudo -= levarDano;
            //Debug.Log(vidaAtualEscudo);
            //if(vidaAtualEscudo <= 0){


                //Escudo.SetActive(false);
                //temEscudo = false;
                
            //}

        //}
    } 
    void CronometroEscudo()
    {
        tempoAtualEscudo -= Time.deltaTime;
        BarraDeVidaEscudo.value = tempoAtualEscudo;

        if (tempoAtualEscudo <= 0)
        {
            Escudo.SetActive(false);
            temEscudo = false;
            BarraDeVidaEscudo.gameObject.SetActive(false);
        }
    }

    
}
