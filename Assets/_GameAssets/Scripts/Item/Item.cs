using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PowerUp
{
    public class Item : MonoBehaviour
    {
        public int vida;
        public int municionPistola;
        public int municionSniper;
        public int municionGranada;

        void Update()
        {

        }
        private void OnTriggerEnter(Collider other)
        {


            if (municionGranada > 0)
            {
                other.gameObject.GetComponentInChildren<Arma>().cantidadMunicion += municionGranada;

            }
            if (municionPistola > 0)
            {
                other.gameObject.GetComponentInChildren<Arma>().cantidadMunicion += municionPistola;

            }
            if (municionSniper > 0)
            {
                other.gameObject.GetComponentInChildren<ArmaSniper>().cantidadMunicion += municionSniper;
            }
            if (vida > 0)
            {
                other.gameObject.GetComponent<Player>().vida += vida;
            }
             Destroy(gameObject);
        }
    }
}
