using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigos : MonoBehaviour
{
    [Header("Lazers do Inimigo")]
    public  GameObject      lazerInimigo;
    public  Transform       localLazerInimigo;
    private bool            inimigoAtivado;
    public  bool            podeAtirar;
    public  int             danoFisico;

    [Header("Cronômetro de disparo")]
    public  float           tempoMaxDisparoEntreLazers;
    private float           tempoAtualDosDisparos;
    
    [Header("Movimentos do inimigo")]
    public  float           speed;

    [Header("Vida do inimigo")]
    public  int             vidaMaxInimigo;
    private int             vidaAtualInimigo;
    public  int             pontosDoInimigo;

    [Header("Drop de Itens")]
    public  GameObject[]    itens;
    public  float           chanceDeDrop;

    [Header("Efeito explosão")]
    public  GameObject          efeitoExplosao;
    
    void Start()
    {
        inimigoAtivado = false;
        vidaAtualInimigo = vidaMaxInimigo;
    }

    
    void Update()
    {
        MovimentoInimigos();

        if(podeAtirar && inimigoAtivado){

            AtaqueInimigo();
        }
    }

    public void AtivarInimigo(){

        inimigoAtivado = true;
    }

    void MovimentoInimigos(){

        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void AtaqueInimigo(){

        tempoAtualDosDisparos -= Time.deltaTime;
        if(tempoAtualDosDisparos <= 0){

            Instantiate(lazerInimigo, localLazerInimigo.position, Quaternion.Euler(0f, 0f, 180f));
            tempoAtualDosDisparos = tempoMaxDisparoEntreLazers;
        }
    }

    public void LevarDano(int levarDanoInimigo){

        vidaAtualInimigo -= levarDanoInimigo;
        SoundManager.Instance.SomLaserInimigo.Play();

        if(vidaAtualInimigo <= 0){

            Debug.Log("Inimigo derrotado");
            GameManager.Instance.AumentarPontuacao(pontosDoInimigo);
            Instantiate(efeitoExplosao, transform.position, transform.rotation);
            SoundManager.Instance.somExplosão.Play();

            SortearDrop();
            Destroy(this.gameObject);
        }
    }

    void SortearDrop(){

        int numeroAleatorio = Random.Range(0, 101);

        if(numeroAleatorio <= chanceDeDrop){

            GameObject itemEscolhido = itens[Random.Range(0, itens.Length)];
            Instantiate(itemEscolhido, transform.position, Quaternion.Euler(0f, 0f, 0f));
        }
    } 

    void OnTriggerEnter2D(Collider2D other){

        if(other.gameObject.CompareTag("Player")){

            other.gameObject.GetComponent<VidaPlayer>().DanoPlayer(danoFisico);
            Instantiate(efeitoExplosao, transform.position, transform.rotation);
            SoundManager.Instance.somExplosão.Play();
            Destroy(this.gameObject);
        }
        if(other.gameObject.CompareTag("AtivarInimigo")){

            AtivarInimigo();
        }
    }
    

    
}
