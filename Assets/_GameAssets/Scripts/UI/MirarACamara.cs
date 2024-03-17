using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirarACamara : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        // Obtener la cámara principal
        mainCamera = Camera.main;

        if (mainCamera == null)
        {
            Debug.LogError("No se ha encontrado la cámara principal en la escena.");
        }
    }

    void Update()
    {
        // Asegurarse de que hay una cámara principal y que el objeto de texto está asignado
        if (mainCamera != null && transform != null)
        {
            // Calcular la rotación necesaria para que el objeto de texto mire hacia la cámara
            Vector3 lookAtDirection = mainCamera.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(lookAtDirection);

            // Aplicar la rotación al objeto de texto
            transform.rotation = rotation;
        }
    }
}
