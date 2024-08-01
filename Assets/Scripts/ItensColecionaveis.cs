using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItensColecionaveis : MonoBehaviour
{
    [Header("Itens")]
    public bool                 itemEscudo;
    public bool                 itemPowerUp;
    public bool                 itemLifeUp;

    [Header("Pontos")]
    public float speed;
    public int                  darVida;
    public static int          numUpgrade = 0;

    [Header("Scripts")]
    private PlayerController    player;

    void Start(){

        player = FindObjectOfType<PlayerController>();
    }

    void Update(){

        MovimentoItens();
    }

    void MovimentoItens(){

        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
    
    void OnTriggerEnter2D(Collider2D other){

        if(other.gameObject.CompareTag("Player")){

            if(itemEscudo == true){
                
                other.gameObject.GetComponent<VidaPlayer>().temEscudo = false;

                other.gameObject.GetComponent<VidaPlayer>().tempoAtualEscudo = other.gameObject.GetComponent<VidaPlayer>().tempoMaxEscudo;
                
                other.gameObject.GetComponent<VidaPlayer>().AtivarEscudo();
                
            }
            else if(itemPowerUp == true){

                numUpgrade++;
                Debug.Log("numUpgrade: " + numUpgrade);
                if(numUpgrade == 1){

                    other.gameObject.GetComponent<PlayerController>().laserDuplo = true;
                }
                else if(numUpgrade == 2){

                    other.gameObject.GetComponent<PlayerController>().laserTriplo = true;
                    numUpgrade = 2;
                }
            }
            else if(itemLifeUp == true){

                other.gameObject.GetComponent<VidaPlayer>().GanharVida(darVida);
            }

                Destroy(gameObject);
        }
    }
}
