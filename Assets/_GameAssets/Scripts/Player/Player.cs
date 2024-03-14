using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
   // public Animator animator;
    private float x, y;
    public float fuerzaSalto = 10.0f;
    public float velRotate = 200.0f;
    public float velMovimiento = 5.0f;
    private GameObject player;
    private Rigidbody rbPlayer;
    private bool estaEnSuelo = true;
    public AudioClip audioSalto;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rbPlayer = player.GetComponent<Rigidbody>();
       // animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * velRotate, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velMovimiento);

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


    }
    private void OnCollisionEnter(Collision other)
    {
        estaEnSuelo = true;
    }
}
