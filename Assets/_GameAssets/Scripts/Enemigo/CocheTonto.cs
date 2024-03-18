using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
using System.Threading;

public class CocheTonto : MonoBehaviour
{
    public float speed;
    public float minAngle;
    public float maxAngle;
    private GameObject player;

    private GameObject suelo;

    public int manejadordrop = 5;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        suelo = GameObject.FindWithTag("Suelo");
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }

    void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Suelo"))
        {

            transform.Rotate(0, UnityEngine.Random.Range(minAngle, maxAngle), 0);

        }
        if (other.gameObject.CompareTag("BalaPistola"))
        {
            if (player != null)
            {

                player.GetComponent<SistemaPuntos>().puntuacion += 1;

            }

            int dropea = UnityEngine.Random.Range(0, manejadordrop);

            if (dropea == 0){
                print("Dropea");
                gameObject.GetComponent<DropeoItem>().SoltarObjeto();
            }
            print("Destruido");
            Destroy(gameObject, 1);
        }
    }
}




