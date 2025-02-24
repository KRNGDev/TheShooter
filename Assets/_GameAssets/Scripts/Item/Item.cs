using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace PowerUp
{
    public class Item : MonoBehaviour
    {
        public int vida = 0;
        public int vidaMax = 0;
        public int municion = 0;
        public int tiempo = 0;
        public GameObject textItem;
        private int playerMaxVida;
        void Start()
        {
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 5, ForceMode.Impulse);

        }
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {

                if (municion > 0)
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
                            other.gameObject.GetComponentInChildren<ArmaGranada>().cantidadMunicion += municion;
                            textItem.GetComponentInChildren<TextMeshProUGUI>().SetText(municion.ToString() + " Granadas");
                            Instantiate(textItem, transform.position, transform.rotation);
                            break;
                        default:
                            break;
                    }

                }
                if (vidaMax > 0)
                {
                    other.gameObject.GetComponent<Player>().maxVida += vidaMax;
                    textItem.GetComponentInChildren<TextMeshProUGUI>().SetText(vidaMax.ToString() + " Vida Max ");
                    Instantiate(textItem, transform.position, transform.rotation);
                }


                if (vida > 0)
                {
                    int playerVida = other.gameObject.GetComponent<Player>().vida;
                    int playerMaxVida = other.gameObject.GetComponent<Player>().maxVida;

                    if (playerVida < playerMaxVida)
                    {

                        print("Ganas vida");

                        if ((vida + playerVida) >= playerMaxVida)
                        {

                            int vidaRestante = playerMaxVida - playerVida;
                            other.gameObject.GetComponent<Player>().vida = playerMaxVida;
                            textItem.GetComponentInChildren<TextMeshProUGUI>().SetText(vidaRestante.ToString() + "+ Vida ");
                            Instantiate(textItem, transform.position, transform.rotation);

                        }
                        else
                        {
                            other.gameObject.GetComponent<Player>().vida += vida;
                            textItem.GetComponentInChildren<TextMeshProUGUI>().SetText(vida.ToString() + "+ Vida");
                            Instantiate(textItem, transform.position, transform.rotation);
                        }

                    }
                    else
                    {
                        textItem.GetComponentInChildren<TextMeshProUGUI>().SetText("+ Vida al MAX");
                        Instantiate(textItem, transform.position, transform.rotation);
                    }

                }

                if (tiempo > 0)
                {
                    SubirTiempo();

                }
                Destroy(gameObject);
            }
        }
        void SubirTiempo()
        {

            GameObject.Find("GameManager").GetComponent<TiempoCuentaAtras>().tiempoRestante += tiempo;
            textItem.GetComponentInChildren<TextMeshProUGUI>().SetText(tiempo.ToString() + "+ Tiempo extra");
                            Instantiate(textItem, transform.position, transform.rotation);



        }

    }
}
