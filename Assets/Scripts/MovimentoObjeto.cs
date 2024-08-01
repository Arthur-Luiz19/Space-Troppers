using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoObjeto : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        Mover();
    }

    void Mover(){

        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
