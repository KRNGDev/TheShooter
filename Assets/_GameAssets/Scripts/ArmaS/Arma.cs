using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Video;

public class Arma : MonoBehaviour
{
    public int capacidadCargador;
    public int cantidadMunicion = 0;
    public int municionCargada;
    public GameObject textoBalasPistola;
    public GameObject prfabBala;
    public Transform transforEmisor;
    public float fuerzaDisparo = 50.0f;
    public AudioClip audioSinBalas;
    public AudioClip audioDisparo;
    public AudioClip audioReload;

    void Start()
    {
        textoBalasPistola.GetComponentInChildren<TextMeshProUGUI>().SetText(municionCargada.ToString());
    }
    
    public void IntentarDisparo()
    {
        if (municionCargada > 0)
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
        municionCargada--;
        textoBalasPistola.GetComponentInChildren<TextMeshProUGUI>().SetText(municionCargada.ToString());

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
        if (cantidadMunicion > 0)
        {
            if (cantidadMunicion >= capacidadCargador)
            {
                int municionNecesaria= capacidadCargador-municionCargada;
                municionCargada = municionNecesaria;
                cantidadMunicion -= municionNecesaria;
            }
            else
            {
                int municionNecesaria= cantidadMunicion-municionCargada;
                municionCargada = municionNecesaria;
                cantidadMunicion -= municionNecesaria;
            }

            textoBalasPistola.GetComponentInChildren<TextMeshProUGUI>().SetText(municionCargada.ToString());

        }

    }

}
