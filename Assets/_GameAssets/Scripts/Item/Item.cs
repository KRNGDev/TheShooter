using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace PowerUp
{
    public class Item : MonoBehaviour
    {
        public int vida = 0;
        public int municion = 0;
        public GameObject textItem;
        void Update()
        {

        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {

                if (!(vida > 0))
                {
                    municion = Random.Range(3, 20);

                    int tipoMunicion = Random.Range(1, 3);
                    switch (tipoMunicion)
                    {
                        case 1://Municion pinstola
                            other.gameObject.GetComponentInChildren<Arma>().cantidadMunicion += municion;
                            textItem.GetComponentInChildren<TextMeshProUGUI>().SetText(municion.ToString() + " Balas Pistola");
                            Instantiate(textItem, transform.position, transform.rotation);

                            break;
                        case 2://Municion Sniper
                            other.gameObject.GetComponentInChildren<ArmaSniper>().cantidadMunicion += municion;
                            textItem.GetComponentInChildren<TextMeshProUGUI>().SetText(municion.ToString() + " Balas Sniper");
                            Instantiate(textItem, transform.position, transform.rotation);
                            break;
                        case 3://Municion Granada
                            other.gameObject.GetComponentInChildren<Arma>().cantidadMunicion += municion;
                            textItem.GetComponentInChildren<TextMeshProUGUI>().SetText(municion.ToString() + " Granadas");
                            Instantiate(textItem, transform.position, transform.rotation);
                            break;
                        default:
                            break;
                    }

                }


                if (vida > 0)
                {
                    int playerVida = other.gameObject.GetComponent<Player>().vida;
                    int playerMaxVida = other.gameObject.GetComponent<Player>().maxVida;
                    if (playerVida < playerMaxVida)
                    {
                        int vidaNecesaria = playerMaxVida - playerVida;

                        print("Ganas vida");

                        if ((vida + vidaNecesaria) > playerMaxVida)
                        {
                            playerVida = playerMaxVida;
                        }
                        else
                        {
                            other.gameObject.GetComponent<Player>().vida += vida;
                            textItem.GetComponentInChildren<TextMeshProUGUI>().SetText(vida.ToString() + " Vida");
                            Instantiate(textItem, transform.position, transform.rotation);
                        }

                    }
                }
                Destroy(gameObject);
            }
        }
    }
}
