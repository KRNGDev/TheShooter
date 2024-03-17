using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Video;

public class Arma : MonoBehaviour
{
    public int capacidadCargador = 0;
    public int cantidadMunicion = 0;
    public int municionCargada = 0;
    public GameObject textoBalasPistola;
    public GameObject textoCantidadBalas;
    public GameObject prfabBala;
    public Transform transforEmisor;
    public float fuerzaDisparo = 50.0f;
    public AudioClip audioSinBalas;
    public AudioClip audioDisparo;
    public AudioClip audioReload;

    void Awake()
    {
        municionCargada = capacidadCargador;
        if (textoBalasPistola && textoCantidadBalas)
        {
            textoCantidadBalas.GetComponentInChildren<TextMeshProUGUI>().SetText(cantidadMunicion.ToString());
            textoBalasPistola.GetComponentInChildren<TextMeshProUGUI>().SetText(municionCargada.ToString());
        }

    }
    private void Update()
    {
        if (textoBalasPistola && textoCantidadBalas)
        {
            textoCantidadBalas.GetComponentInChildren<TextMeshProUGUI>().SetText(cantidadMunicion.ToString());
            textoBalasPistola.GetComponentInChildren<TextMeshProUGUI>().SetText(municionCargada.ToString());
        }
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


            int municionNecesaria = capacidadCargador - municionCargada;
            if (municionNecesaria > cantidadMunicion || (municionCargada + cantidadMunicion) >= capacidadCargador)
            {
                if (municionNecesaria >= cantidadMunicion)
                {
                    print("eleccion");
                    municionCargada += cantidadMunicion;
                    cantidadMunicion = 0;
                }
                else
                {
                    municionCargada += municionNecesaria;
                    cantidadMunicion -= municionNecesaria;
                }



                textoBalasPistola.GetComponentInChildren<TextMeshProUGUI>().SetText(municionCargada.ToString());
                textoCantidadBalas.GetComponentInChildren<TextMeshProUGUI>().SetText(cantidadMunicion.ToString());
            }
        }
        if (cantidadMunicion < 0)
        {
            cantidadMunicion = 0;
        }

    }

}
