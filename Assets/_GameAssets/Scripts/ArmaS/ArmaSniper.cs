using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ArmaSniper : MonoBehaviour
{
    public int capacidadCargador;
    public int cantidadMunicion = 0;
    public int municionCargada;
    public GameObject textoBalasSniper;
    public float radioExpansion;
    public float fuerzahorizontal;
    public float fuerzaVertical;
    public float distanciaGolpe;
    public GameObject explosion;

    public Transform transformOrigenRaycast;
    public float fuerzaDisparo = 50.0f;
    public AudioClip audioSinBalas;
    public AudioClip audioDisparo;
    public AudioClip audioReload;
    void Start()
    {
        textoBalasSniper.GetComponentInChildren<TextMeshProUGUI>().SetText(municionCargada.ToString());
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
        textoBalasSniper.GetComponentInChildren<TextMeshProUGUI>().SetText(municionCargada.ToString());
        RaycastHit hitInfo;
        bool hayImpacto = Physics.Raycast(transformOrigenRaycast.position, transformOrigenRaycast.forward, out hitInfo);
        if (hayImpacto)
        {

            Vector3 posicionFinal = hitInfo.point - hitInfo.normal * distanciaGolpe;
            // hitInfo.transform.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
            //hitInfo.transform.GetComponentInChildren<Rigidbody>().AddForce(Vector3.forward * fuerzaDisparo);
            //hitInfo.transform.GetComponentInChildren<Rigidbody>().AddExplosionForce(fuerzahorizontal,posicionFinal,radioExpansion,fuerzaVertical);
            Instantiate(explosion, posicionFinal, hitInfo.transform.rotation);

            if (hitInfo.transform.CompareTag("Suelo"))
            {
                hitInfo.transform.GetComponentInChildren<Rigidbody>().AddForce(Vector3.forward * fuerzaDisparo);
            }

        }


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
            if (cantidadMunicion > 0)
            {
                if (cantidadMunicion > capacidadCargador)
                {
                    int municionNecesaria = capacidadCargador - municionCargada;
                    municionCargada = municionNecesaria;
                    cantidadMunicion -= municionNecesaria;
                }
                else
                {
                    int municionNecesaria = cantidadMunicion - municionCargada;
                    municionCargada = municionNecesaria;
                    cantidadMunicion -= municionNecesaria;
                }
                textoBalasSniper.GetComponentInChildren<TextMeshProUGUI>().SetText(municionCargada.ToString());
            }
        }


    }
}
