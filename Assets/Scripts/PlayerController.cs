using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Componentes")]
    private Rigidbody2D     rig;
    private Animator        PA;
    
    [Header("Movimentos")]
    public  float           speed;
    private Vector2         teclasApertadas;
    private bool            facingRight;

    public GameObject       laserDoJogador;
    public Transform        localDoLaser;
    public bool             laserDuplo;
    
    
    void Start()
    {
        laserDuplo = false;
        rig = GetComponent<Rigidbody2D>();
        PA = GetComponent<Animator>();
    }

    
    void Update()
    {
        Movimentos();
        TocarMovimentos();
        AtirarLaser();
        
    }

    void Movimentos(){

        teclasApertadas = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rig.velocity = teclasApertadas.normalized * speed;

        if(teclasApertadas.x < 0 && facingRight || teclasApertadas.x > 0 && !facingRight){

            Flip();
        }
    }

    void TocarMovimentos(){

        if(teclasApertadas.x == 0){

            PA.SetTrigger("Idle");
        }
        else if (teclasApertadas.x != 0){

            PA.SetTrigger("isWalk");
        }
    }

    void Flip(){

        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    void AtirarLaser(){

        if(Input.GetButtonDown("Fire1")){

            if(laserDuplo == false){

                Instantiate(laserDoJogador, localDoLaser.position, localDoLaser.rotation);
                
            }
        }
    }
}
