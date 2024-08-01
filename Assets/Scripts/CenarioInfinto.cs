using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenarioInfinto : MonoBehaviour
{
    public float velocidadeCenario;

    // Update is called once per frame
    void Update()
    {
        MovimentarCenario();
    }

    void MovimentarCenario(){

        Vector2 deslocamentoCena = new Vector2(0f, Time.time * velocidadeCenario);
        GetComponent<Renderer>().material.mainTextureOffset = deslocamentoCena;
    }
}
