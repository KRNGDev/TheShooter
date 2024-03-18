using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class EnemigoPersigue : MonoBehaviour
{
    private GameObject player;
    public int velocidadMov = 4;
    private int rutina;
    public float cronometro;
    public Quaternion angulo;
    public float grado;

    private GameObject targetEnemigo;
    public bool atacando;
    public bool puedeDisparar = true;
    DisparoEnemigo disparo;

    public int manejadordrop = 5;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        targetEnemigo = GameObject.FindGameObjectWithTag("Player");
        disparo = GetComponent<DisparoEnemigo>();
    }

    // Update is called once per frame
    void Update()
    {
        ComportamientoEnemigo();
    }
    public void ComportamientoEnemigo()
    {
        if (Vector3.Distance(transform.position, targetEnemigo.transform.position) > 30)
        {

            cronometro += 1 * Time.deltaTime;
            if (cronometro >= 4)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }
            switch (rutina)
            {
                case 0:

                    break;

                case 1:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    break;

                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);

                    break;

            }

        }
        else
        {
            if (Vector3.Distance(transform.position, targetEnemigo.transform.position) > 15)
            {
                var lookPos = targetEnemigo.transform.position - transform.position;
                // lookPos.y = 0;
                var rotacion = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacion, 2);

                transform.Translate(Vector3.forward * velocidadMov * Time.deltaTime);
            }
            else
            {
                var lookPos = targetEnemigo.transform.position - transform.position;
                lookPos.y = 0;
                var rotacion = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacion, 2);

                if (puedeDisparar)
                {


                    puedeDisparar = false;
                    InvokeRepeating("TiempoEspera", 1f, 2);
                }



            }
        }

    }

    void TiempoEspera()
    {


        disparo.Disparar();
        puedeDisparar = true;
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("BalaPistola"))
        {
            if (player != null)
            {

                player.GetComponent<SistemaPuntos>().puntuacion += 1;

            }
            int dropea = Random.Range(0, manejadordrop);

            if (dropea == 0){
                print("Dropea");
                gameObject.GetComponent<DropeoItem>().SoltarObjeto();
            }
                Destroy(gameObject, 1);
        }


    }
}
