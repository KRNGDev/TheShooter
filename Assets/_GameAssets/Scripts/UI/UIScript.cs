using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{

    public GameObject panelMenu;
    public GameObject panelLogo;
    public AudioClip boton;

    private GameObject player;

    public bool desactivado = true;

    void Start()
    {
        player = GameObject.FindWithTag("Player");

    }
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!player)
            {
                panelLogo.SetActive(true);
                if (desactivado)
                {
                    panelMenu.SetActive(true);
                    panelLogo.SetActive(false);
                    GetComponent<AudioSource>().PlayOneShot(boton);
                    //Time.timeScale = 0;
                    desactivado = false;
                }
                else if (!desactivado)
                {
                    panelMenu.SetActive(false);
                    panelLogo.SetActive(true);
                    //Time.timeScale = 1;
                    desactivado = true;
                }
            }
            else
            {
                if (desactivado)
                {
                    panelMenu.SetActive(true);
                    Time.timeScale = 0;
                    desactivado = false;
                }
                else if (!desactivado)
                {
                    panelMenu.SetActive(false);
                    Time.timeScale = 1;
                    desactivado = true;
                }
            }
        }
    }

    // Start is called before the first frame update
    public void Reset()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Terreno");

    }
    public void CargarMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Intro");
    }

    // Update is called once per frame
    public void Exit()
    {
        Application.Quit();
    }
}
