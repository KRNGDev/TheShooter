
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class SpawnerManager : MonoBehaviour
{
    public GameObject[] enemigos;
    public Transform[] spawners;
    private Collider[] collidersHijos;
    public float tiempoEspera = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        collidersHijos = GetComponentsInChildren<Collider>();

        InvokeRepeating("SpawnerEnemigos", tiempoEspera, tiempoEspera);
        //StartCoroutine(SpawnerEnemigos());
    }
    void AlgienDentro()
    {
        foreach (Collider c in collidersHijos)
        {
            OnTriggerEnter(c);

        }
    }
    void OnTriggerEnter(Collider other)
    {

    }

    private void SpawnerEnemigos()
    {


        GameObject enemigoAleatoio = enemigos[Random.Range(0, enemigos.Length - 1)];
        Transform spawnRandom = spawners[Random.Range(0, spawners.Length - 1)];

        Instantiate(enemigoAleatoio, spawnRandom.position, spawnRandom.rotation);



    }

}
