using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // public Animator animator;
    private float x, y;
    public int vida = 102;
    public float fuerzaSalto = 10.0f;
    public float velRotate = 200.0f;
    public float velMovimiento = 5.0f;
    private GameObject player;
    private Rigidbody rbPlayer;
    private bool estaEnSuelo = true;
    public AudioClip audioSalto;
    public GameObject panelGameOver;




    public GameObject textVida;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rbPlayer = player.GetComponent<Rigidbody>();
        // animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {/*
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * velRotate, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velMovimiento);*/

        if (vida <= 0)
        {
            panelGameOver.SetActive(true);
            Destroy(gameObject);
        }
        /*
                //  animator.SetFloat("X", x);
                // animator.SetFloat("Y", y);
                if (Input.GetButtonDown("Jump") && estaEnSuelo)
                {

                    rbPlayer.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
                    estaEnSuelo = false;
                    if (audioSalto != null)
                    {
                        GetComponent<AudioSource>().PlayOneShot(audioSalto);
                    }

       

    }
 */

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Suelo"))
        {
            estaEnSuelo = true;
        }


        if (other.gameObject.CompareTag("Enemigo"))
        {
            vida--;
        }

        textVida.GetComponentInChildren<TextMeshProUGUI>().SetText(vida.ToString());
    }
}
