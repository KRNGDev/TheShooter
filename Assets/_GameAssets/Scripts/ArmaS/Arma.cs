using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Arma : MonoBehaviour
{
    public int capacidadCargador = 100;
    public int municion = 0;
    public GameObject prfabBala;
    public Transform transforEmisor;
    public float fuerzaDisparo = 50.0f;
    public AudioClip audioSinBalas;
    public AudioClip audioDisparo;
    public AudioClip audioReload;


    public void IntentarDisparo()
    {
        if (municion > 0)
        {

            Disparar();
        }
        else
        {
            if (audioSinBalas != null)
            {
                GetComponent<AudioSource>().PlayOneShot(audioSinBalas);
            }

        }

    }
    public void Disparar()
    {
        municion--;

        GameObject bala = Instantiate(prfabBala, transforEmisor.position, transforEmisor.rotation);
        bala.GetComponent<Rigidbody>().AddForce(bala.transform.forward * fuerzaDisparo);

        if (audioDisparo != null)
        {

            GetComponent<AudioSource>().PlayOneShot(audioDisparo);
        }


    }
    public void Reload()
    {
        if (audioReload != null)
        {
            GetComponent<AudioSource>().PlayOneShot(audioReload);
        }

        municion = capacidadCargador;

    }

}
