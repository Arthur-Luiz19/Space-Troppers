using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempoParaDestruir : MonoBehaviour
{
    
    public GameObject Objeto;
    public float tempoDestruir;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destruir();
    }

    void Destruir(){

        Destroy(Objeto, tempoDestruir);
    }
}
