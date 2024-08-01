using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerDoPlayer : MonoBehaviour
{
    [Header("Velocidade de disparo")]
    public float speed;

    [Header("Dano para infligir")]
    public int darDano;

    [Header("impacto de Laser")]
    public GameObject impactoLaser;

    void Start()
    {
        
    }

    
    void Update()
    {
        MovimentoTiro();
    }

    void MovimentoTiro(){

        transform.Translate(Vector3.up * speed * Time.deltaTime);
        Destroy(gameObject, 1.0f);
    }

    void OnTriggerEnter2D(Collider2D coll){

        if(coll.gameObject.CompareTag("Inimigo")){

            coll.gameObject.GetComponent<Inimigos>().LevarDano(darDano);
            Instantiate(impactoLaser, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
