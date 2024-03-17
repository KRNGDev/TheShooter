using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class ArmaSniper : MonoBehaviour
{
    public int capacidadCargador = 0;
    public int cantidadMunicion = 0;
    public int municionCargada = 0;
    public GameObject textoBalasSniper;
    public GameObject textoCantidadBalas;
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
    
    private void Awake() {
        if (textoBalasSniper && textoCantidadBalas)
        {
            textoCantidadBalas.GetComponentInChildren<TextMeshProUGUI>().SetText(cantidadMunicion.ToString());
            textoBalasSniper.GetComponentInChildren<TextMeshProUGUI>().SetText(municionCargada.ToString());
        }
    }
    void Start()
    {
        municionCargada = capacidadCargador;
        cantidadMunicion= capacidadCargador;

    }
    private void Update()
    {
        if (textoBalasSniper && textoCantidadBalas)
        {
            textoCantidadBalas.GetComponentInChildren<TextMeshProUGUI>().SetText(cantidadMunicion.ToString());
            textoBalasSniper.GetComponentInChildren<TextMeshProUGUI>().SetText(municionCargada.ToString());
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



                textoBalasSniper.GetComponentInChildren<TextMeshProUGUI>().SetText(municionCargada.ToString());
                textoCantidadBalas.GetComponentInChildren<TextMeshProUGUI>().SetText(cantidadMunicion.ToString());
            }
        }


    }

}
