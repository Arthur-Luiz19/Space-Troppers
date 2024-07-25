using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigos : MonoBehaviour
{
    public float speed;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        MovimentoInimigos();
    }

    void MovimentoInimigos(){

        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
