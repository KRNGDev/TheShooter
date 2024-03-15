using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CocheTonto : MonoBehaviour
{
    public float speed;
    public float minAngle;
    public float maxAngle;

    private GameObject suelo;
    void Start()
    {
        suelo = GameObject.FindWithTag("Suelo");
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != suelo.tag)
        {

            transform.Rotate(0, Random.Range(minAngle, maxAngle), 0);

        }
    }

}
