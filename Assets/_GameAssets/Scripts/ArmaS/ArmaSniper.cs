using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ArmaSniper : MonoBehaviour
{
    public int capacidadCargador = 100;
    public int municion = 0;
    public float radioExpansion;
    public float fuerzahorizontal;
    public float fuerzaVertical;
    public float distanciaGolpe;
    public GameObject explosion;

    public Transform transforEmisor;
    public Transform transformOrigenRaycast;
    public float fuerzaDisparo = 50.0f;
    public AudioClip audioSinBalas;
    public AudioClip audioDisparo;
    public AudioClip audioReload;

    private int puntuacion = 0;

    public int puntosSnipper = 1; 

    public GameObject textObject;

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
        RaycastHit hitInfo;
        bool hayImpacto = Physics.Raycast(transformOrigenRaycast.position, transformOrigenRaycast.forward, out hitInfo);
        if (hayImpacto)
        {

            Vector3 posicionFinal = hitInfo.point - hitInfo.normal * distanciaGolpe;
            // hitInfo.transform.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
            //hitInfo.transform.GetComponentInChildren<Rigidbody>().AddForce(Vector3.forward * fuerzaDisparo);
            //hitInfo.transform.GetComponentInChildren<Rigidbody>().AddExplosionForce(fuerzahorizontal,posicionFinal,radioExpansion,fuerzaVertical);
            Instantiate(explosion, posicionFinal, hitInfo.transform.rotation);
            hitInfo.transform.GetComponentInChildren<Rigidbody>().AddForce(Vector3.forward * fuerzaDisparo);
            /* if (hitInfo.transform.CompareTag("Enemigo"))
            {


            }*/

            puntuacion = puntuacion + puntosSnipper;
            print("puntuacionSNIPER: " + puntuacion);


            textObject.GetComponentInChildren<TextMeshProUGUI>().SetText(puntuacion.ToString());

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

        municion = capacidadCargador;

    }
}
