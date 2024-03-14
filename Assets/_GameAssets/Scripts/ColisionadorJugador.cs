using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionadorJugador : MonoBehaviour
{
    public GameObject boton;
    public GameObject mensajeKey;
    public GameObject consegirKey;
    public Boolean key = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Puerta") && key == true)
        {
            if (boton != null)
            {
                boton.SetActive(true);
            }
        }
        else if (other.CompareTag("Key"))
        {
            key = true;
            if (consegirKey != null)
            {
                GetComponent<Inventario>().addItem(other.gameObject);
                consegirKey.SetActive(true);
            }
            Destroy(other.gameObject);
        }
        else
        {
            if (mensajeKey != null)
            {
                mensajeKey.SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Puerta"))
        {
            if (boton != null)
            {
                boton.SetActive(false);
            }
            mensajeKey.SetActive(false);
        }
    }

}
