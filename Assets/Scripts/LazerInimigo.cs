using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerInimigo : MonoBehaviour
{
    [Header("Velocidade de disparo")]
    public float speed;

    [Header("Dano para infligir")]
    public int qtdDano;

    [Header("Impacto de Laser do inimigo")]
    public GameObject impactoLaserInimigo;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        VelocidadeDisparo();
    }

    void VelocidadeDisparo(){

        transform.Translate(Vector3.up * speed * Time.deltaTime);
        Destroy(gameObject, 1.0f);
    }

    void OnTriggerEnter2D(Collider2D col){

        if(col.gameObject.CompareTag("Player")){
            
            col.gameObject.GetComponent<VidaPlayer>().DanoPlayer(qtdDano);
            Instantiate(impactoLaserInimigo, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
        
    }
}
