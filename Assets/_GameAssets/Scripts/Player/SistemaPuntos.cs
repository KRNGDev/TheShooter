using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SistemaPuntos : MonoBehaviour
{
    public int puntuacion;
    public GameObject textoPuntos;
    // Start is called before the first frame update
   
    void Update()
    {
        textoPuntos.GetComponentInChildren<TextMeshProUGUI>().SetText(puntuacion.ToString());

        
    }
}
