using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class ArmaPlayer : MonoBehaviour
{
    public Arma arma;
    public Arma granada;
    public ArmaSniper sniper;

    public Boolean armaBool = true;
    public Boolean sniperBool = false;
    public Boolean granadaBool = false;

    public Image crossHair;
    public GameObject camara1Persona;
    public GameObject camaraPrincipal;

    public GameObject armaSecundaria;

    public GameObject armaArrojadiza;

    private void Awake()
    {


        armaSecundaria.SetActive(true);

        armaArrojadiza.SetActive(true);
    }
    private void Start()
    {


        armaSecundaria.SetActive(false);

        armaArrojadiza.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ApretarGatillo();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            if (armaBool)
            {
                arma.Reload();
            }
            else if (sniperBool)
            {
                print("Recarga");
                sniper.Reload();
            }
            else if (granadaBool)
            {

                granada.Reload();
            }

        }
        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            camaraPrincipal.SetActive(false);
            sniperBool = true;
            armaBool = false;

            //Activa el crossHair
            crossHair.enabled = true;
            //Modifica el fieldofview de la camara
            camara1Persona.SetActive(true);
            camara1Persona.gameObject.GetComponent<Camera>().fieldOfView = 18;

            /* this.gameObject.GetComponent<Player>().enabled = false;
             this.gameObject.GetComponent<FPSController>().enabled = true;
             this.gameObject.GetComponent<CharacterController>().enabled = true;*/




        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            armaBool = true;
            sniperBool = false;
            /* this.gameObject.GetComponent<Player>().enabled = true;
             this.gameObject.GetComponent<FPSController>().enabled = false;
             this.gameObject.GetComponent<CharacterController>().enabled = false;*/
            //Activa el crossHair
            crossHair.enabled = false;
            //Modifica el fieldofview de la camara
            camara1Persona.gameObject.GetComponent<Camera>().fieldOfView = 18;
            camara1Persona.SetActive(false);
            camaraPrincipal.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            armaBool = false;
            sniperBool = false;
            granadaBool = true;


        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            armaBool = true;
            sniperBool = false;
            granadaBool = false;


        }

    }
    public void ApretarGatillo()
    {
        if (armaBool)
        {
            arma.IntentarDisparo();
        }
        else if (sniperBool)
        {
            print("Dispara");
            sniper.IntentarDisparo();
        }
        else if (granadaBool)
        {

            granada.IntentarDisparo();
        }
    }

}
