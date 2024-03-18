using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoEnemigo : MonoBehaviour
{

    public GameObject prfabBala;
    public Transform transforEmisor;
    public float fuerzaDisparo = 50.0f;
    public AudioClip audioDisparo;
    public EnemigoPersigue enemigo;


    public void Disparar()
    {
        GameObject bala = Instantiate(prfabBala, transforEmisor.position, transforEmisor.rotation);
        bala.GetComponent<Rigidbody>().AddForce(bala.transform.forward * fuerzaDisparo);
        //Enemigo se autodispara
        //enemigo.puedeDisparar = false;

        if (audioDisparo != null)
        {
            GetComponentInChildren<AudioSource>().PlayOneShot(audioDisparo); 
        }


    }

}
