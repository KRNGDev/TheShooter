using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{

    public GameObject panelMenu;
    public bool desactivado = true; 
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(desactivado){
                panelMenu.SetActive(true); 
                Time.timeScale = 0;
                desactivado = false;
            }else if (!desactivado){
                panelMenu.SetActive(false);
                Time.timeScale = 1;
                desactivado = true;
        }
        }
    }

    // Start is called before the first frame update
    public void Reset()
    {
        SceneManager.LoadScene(1);
    }

   public void CargarMenu()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    public void Exit()
    {
        Application.Quit();
    }
}
