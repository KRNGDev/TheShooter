using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    Transform[] transfoms;
    GameObject[] enemigos;
    int numeroEnemigos;
    float tiempoEntreSpawn;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawnear", tiempoEntreSpawn, tiempoEntreSpawn);
    }

    // Update is called once per frame
    private void Spawnear()
    {

    }
}
