using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainelCréditos : MonoBehaviour
{
    public GameObject painelCreditos;
    void Start()
    {
        painelCreditos.SetActive(false);
    }

    public void MenuCreditos(){

        painelCreditos.SetActive(true);
    }

    public void FecharCreditos(){

        painelCreditos.SetActive(false);
    }

    
}
