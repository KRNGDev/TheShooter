using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicaCambiarDeEscena : MonoBehaviour
{
    public bool pasarnivel;
    public int indiceEscena;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
//        if(Input.GetKeyDown(KeyCode.Space)){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if (indiceEscena == 0 ){
                CambiarDeEscena(indiceEscena);
            }
            else{
                Application.Quit();
            }


        }
        if (pasarnivel){
            CambiarDeEscena(indiceEscena);
        }
    }


    public void CambiarDeEscena(int indice){
        SceneManager.LoadScene(indice);
    }
}
