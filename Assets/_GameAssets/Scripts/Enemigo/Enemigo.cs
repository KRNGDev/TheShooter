using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemigo : MonoBehaviour
{

    public float velRotate = 40.0f;
    public float velMovimiento = 5.0f;
    public GameObject suelo;

    public float x, y;
    public float tiempoEspera;

    private int estado;
    private bool moviendose = false;
    private bool girando = false;
    private bool activo = true;

    // Start is called before the first frame update
    void Start()
    {

if(gameObject.GetComponent<Animator>()!= null){
        StartCoroutine(ActivarMovimientos());
}

    }

    // Update is called once per frame
    void Update()
    {
        if (moviendose)
        {
            transform.Translate(Vector3.forward * velMovimiento * Time.deltaTime);
            if(gameObject.GetComponent<Animator>()!= null){
            y = 1f;
            ;

            //this.gameObject.GetComponent<Animator>().SetFloat("X", x);
            this.gameObject.GetComponent<Animator>().SetFloat("Y", y);
            }
        }


        if (girando)
        {

            x = 0.5f;
            transform.Rotate(Vector3.up * velRotate * Time.deltaTime);
            if(gameObject.GetComponent<Animator>()!= null){
            this.gameObject.GetComponent<Animator>().SetFloat("X", x);
            // this.gameObject.GetComponent<Animator>().SetFloat("Y", y);
            }
        }



    }
    IEnumerator ActivarMovimientos()
    {
        // Debug.Log("Se Activa el enumerator");
        while (activo)
        {
            // Debug.Log("Empienza el while");
            estado = Random.Range(1, 4);
            this.gameObject.GetComponent<Animator>().SetFloat("X", 0);
            switch (estado)
            {

                case 1:
                    y = 0f;
                    x = 0f;

                    this.gameObject.GetComponent<Animator>().SetFloat("X", x);
                    this.gameObject.GetComponent<Animator>().SetFloat("Y", y);
                    moviendose = true;

                    // Debug.Log(" el caso Se mueve");

                    break;
                case 2:
                    //Debug.Log("Gira y avanza");
                    y = 0f;
                    x = 0f;

                    this.gameObject.GetComponent<Animator>().SetFloat("X", x);
                    this.gameObject.GetComponent<Animator>().SetFloat("Y", y);
                    girando = true;
                    moviendose = false;
                    break;
                case 3:
                    //Debug.Log("Quieto");
                    girando = false;
                    moviendose = false;
                    y = 0f;
                    x = 0f;

                    this.gameObject.GetComponent<Animator>().SetFloat("X", x);
                    this.gameObject.GetComponent<Animator>().SetFloat("Y", y);
                    break;
                default:
                    Debug.LogError("Movimiento no reconocido");
                    break;

            }


            yield return new WaitForSeconds(tiempoEspera);
        }


    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Suelo")
        {
            // Debug.Log("Colisiona");
            moviendose = false;
            girando = true;
        }


    }
    void OnDestroy()
    {
        // Detiene la corutina 
        StopCoroutine(ActivarMovimientos());
    }
}
