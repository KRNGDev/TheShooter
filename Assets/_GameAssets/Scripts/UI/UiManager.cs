using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class UiManager : MonoBehaviour
{
    public GameObject panelMenu;
    public GameObject botonMenu;
    public String scene;
    public float tiempoEpera = 0.2f;
    
        // Update is called once per frame 
    public void ActivarPanel()
    {
        panelMenu.SetActive(true);
        botonMenu.SetActive(false);
    }
    public void OcultarPanel()
    {
        panelMenu.SetActive(false);
        botonMenu.SetActive(true);
    }
    public void EjecutarLoadScene(String scene)
    {
        StartCoroutine(EsperarLoadScene(scene));
    }

    public IEnumerator EsperarLoadScene(String scene)
    {
        // Esperar 2 segundos
        yield return new WaitForSeconds(tiempoEpera);

        // Llamar a la función que deseas activar 
        LoadScene(scene);
    }
    IEnumerator EsperarMenuPrincipal()
    {
        // Esperar 2 segundos
        yield return new WaitForSeconds(1);

        // Llamar a la función que deseas activar 
        MenuPrincipal();
    }

    public void LoadScene(String scena)
    {
        SceneManager.LoadScene(scena);
    }
    public void MenuPrincipal()
    {
        SceneManager.LoadScene("Intro");

    }
    public void Salir()
    {
        Application.Quit();
    }
}
