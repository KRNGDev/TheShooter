using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    public float radioExpansion;
    public float fuerzahorizontal;
    public float fuerzaVertical;
    public GameObject explosion;
    [Header("Capa para agurpar a qu objetos ataca")]
    public LayerMask layerMask;

    [Header("Segundos de espera para que explote")]
    public float temporizador;

    void OnCollisionEnter(Collision other)
    {
        Explotar();
    }
    public void Explotar()
    {
        //Obtiene los colliders afectados por la esplosion
        Collider[] hitCollider = Physics.OverlapSphere(transform.position, radioExpansion, layerMask);
        foreach (var collider in hitCollider)
        {
            if (collider.GetComponent<Rigidbody>() != null)
            {

                collider.GetComponent<Rigidbody>().AddExplosionForce(
                    fuerzahorizontal,
                    transform.position,
                    radioExpansion,
                    fuerzaVertical);
                Instantiate(explosion, this.transform.position, this.transform.rotation);

                Destroy(this.gameObject);
            }
        }
    }
}
