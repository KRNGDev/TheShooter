using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TerrainTools;

public class Accionador : MonoBehaviour
{

    public Animator animator;
    public String nombreItemNecesario;
    public String nombreObjeto;
    public String nombreActivadorAnimacion;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //ColisionadorJugador jugador = player.GetComponent<ColisionadorJugador>();

            bool tieneItem = other.gameObject.GetComponent<Inventario>().HasItem(nombreItemNecesario);
            ItemManager item = other.gameObject.GetComponent<ItemManager>();
            Inventario inventario = other.gameObject.GetComponent<Inventario>();

            //Activador si tiene el objeto necesario y lo borra del inventario
            if (tieneItem)
            {
                animator.SetTrigger(nombreActivadorAnimacion);

                inventario.GetItem(nombreItemNecesario);
                if (nombreObjeto != null)
                {
                    if (other.gameObject.tag == nombreObjeto)
                    {


                    }
                }
                //Activa la animacion
                switch (nombreItemNecesario)
                {
                    case "Llave":
                        item.imgLlave.SetActive(false);
                        break;

                    case "Pocion":
                        item.imgPocion.SetActive(false);
                        break;

                    case "Comida":
                        item.imgComida.SetActive(false);
                        break;

                    default:
                        print("No tiene objeto");
                        break;
                }


            }

            //Deteccion con Accionadores


        }


    }
    void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            animator.SetTrigger("Cerrar");

        }


    }
}
