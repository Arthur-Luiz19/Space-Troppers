using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeObjetos : MonoBehaviour
{
    
    public GameObject[] objetosParaSpawnar;
    public Transform[]  pontosDeSpawn;

    public float tempoMaxSpawn;
    public float tempoAtualSpawn;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        CronometroSpawn();
    }

    void SpawnarObjetos(){

         int sortearObjeto = Random.Range(0, objetosParaSpawnar.Length);
         int sortearSpawn = Random.Range(0, pontosDeSpawn.Length);

         Instantiate(objetosParaSpawnar[sortearObjeto], pontosDeSpawn[sortearSpawn].position, Quaternion.identity); 
    }

    void CronometroSpawn(){

        tempoAtualSpawn -= Time.deltaTime;
        if(tempoAtualSpawn <= 0){

            SpawnarObjetos();
            tempoAtualSpawn = tempoMaxSpawn;
        }
    }
}
