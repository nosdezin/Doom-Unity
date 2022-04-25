using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public bool aberto = false;
    public Vector3 posicaoPortaAberta;
    public Vector3 posicaoPortaFechada;
    public float tempo = 2f;

    void Update()
    {
        if(aberto){
            transform.position = posicaoPortaAberta;
            StartCoroutine(doorEnable());
        }
    }

    IEnumerator doorEnable(){
        yield return new WaitForSeconds(tempo);
        transform.position = posicaoPortaFechada;
        aberto = false;
    }
}
