using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerDoPlayer : MonoBehaviour
{
    public float speed;

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
}
