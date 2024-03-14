using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject imgLlave;
    public GameObject imgPocion;
    public GameObject imgComida;
    public GameObject botonPuerta;

    public String itemNecesarioAccion;




    void OnTriggerEnter(Collider other)
    {
        //Para añadir Objetos inventario
        switch (other.gameObject.name)
        {
            case "Llave":

                GetComponent<Inventario>().addItem(other.gameObject);
                Destroy(other.gameObject);
                imgLlave.SetActive(true);
                break;

            case "Pocion":

                GetComponent<Inventario>().addItem(other.gameObject);
                Destroy(other.gameObject);
                imgPocion.SetActive(true);
                break;

            case "Comida":

                GetComponent<Inventario>().addItem(other.gameObject);
                Destroy(other.gameObject);
                imgComida.SetActive(true);
                break;

            default:
                print("no hay nada");
                break;
        }



    }
}
