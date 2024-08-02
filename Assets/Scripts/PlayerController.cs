using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Para acessar componentes UI
using UnityEngine.EventSystems; // Para eventos de UI
using UnityStandardAssets.CrossPlatformInput;




public class PlayerController : MonoBehaviour
{
    [Header("Componentes")]
    private Rigidbody2D     rig;
    private Animator        PA;
    public static PlayerController Instance; 
    
    [Header("Movimentos")]
    public  float           speed;
    private Vector2         teclasApertadas;
    private Vector2         touchRun;
    private bool            facingRight;
    public bool             estaVivo;

    [Header("Disparos")]
    
    //Laser Ùnico
    public GameObject       laserDoJogador;
    public Transform        localDoLaser;

    //Laser Duplo
    public GameObject       laserDuploPlayer;
    public Transform[]      localLaserDuplo;
    public bool             laserDuplo;
    

    //Laser Triplo
    public bool             laserTriplo;
    public GameObject       laserTriploPlayer;
    public Transform[]      localLaserTriplo;
    
    
    void Awake(){

        Instance = this;
    }
    
    void Start()
    {
        estaVivo = true;
        laserDuplo = false;
        laserTriplo = false;
        rig = GetComponent<Rigidbody2D>();
        PA = GetComponent<Animator>();
    }

    
    void Update()
    {
            
        if(estaVivo){

            Movimentos();
            TocarMovimentos();
            AtirarLaser();
        }    
    }

    void FixedUpdate(){

        MovimentosInputMobile(touchRun);
    }

    void Movimentos(){

        teclasApertadas = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rig.velocity = teclasApertadas.normalized * speed;
        touchRun = new Vector2(CrossPlatformInputManager.GetAxisRaw("Horizontal"), CrossPlatformInputManager.GetAxisRaw("Vertical"));

        

        if(teclasApertadas.x < 0 && facingRight || teclasApertadas.x > 0 && !facingRight){

            Flip();
        }
        else if(touchRun.x < 0 && facingRight || touchRun.x > 0 && !facingRight){

            Flip();
        }
        

    }

    void MovimentosInputMobile(Vector2 direction){

        rig.velocity = direction.normalized * speed;
    }

    void TocarMovimentos(){

        if(teclasApertadas.x == 0 || touchRun.x == 0){

            PA.SetTrigger("Idle");
        }
        else if (teclasApertadas.x != 0 || touchRun.x != 0){

            PA.SetTrigger("isWalk");
        }
    }

    public void Flip(){

        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void AtirarLaser(){

        if(CrossPlatformInputManager.GetButtonDown("Fire1")){

            SoundManager.Instance.somLaserPlayer.Play();
            
            if(laserDuplo == false && laserTriplo == false){

                Instantiate(laserDoJogador, localDoLaser.position, localDoLaser.rotation);
                
            }
            else if(laserDuplo == true && laserTriplo == false){

                Instantiate(laserDuploPlayer, localLaserDuplo[0].position, localLaserDuplo[0].rotation);
                Instantiate(laserDuploPlayer, localLaserDuplo[1].position, localLaserDuplo[1].rotation);
            }
            else if(laserDuplo == true && laserTriplo == true){

                Instantiate(laserTriploPlayer, localLaserTriplo[0].position, localLaserTriplo[0].rotation);
                Instantiate(laserTriploPlayer, localLaserTriplo[1].position, localLaserTriplo[1].rotation);
                Instantiate(laserTriploPlayer, localLaserTriplo[2].position, localLaserTriplo[2].rotation);
            }
        }
    }
}
