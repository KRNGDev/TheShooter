
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TiempoCuentaAtras : MonoBehaviour
{

    public float tiempoInicial = 300f; // Tiempo inicial en segundos
    public float tiempoRestante;
    public GameObject panelGameOver;
    public TextMeshProUGUI textoPuntos;
    public AudioSource backgroundMusic;
    public AudioClip musicaTensa;
    public UIScript ui;
    private bool musicaCambiada = false;
    private SistemaPuntos sistemaPuntos;
    private int puntos;

    public TextMeshProUGUI textoCuentaAtras; // Referencia al texto en el UI donde mostrarás el tiempo restante

    void Start()
    {
        sistemaPuntos = GameObject.FindWithTag("Player").GetComponent<SistemaPuntos>();
        tiempoRestante = tiempoInicial;
        puntos = sistemaPuntos.puntuacion;

    }

    void Update()
    {
        tiempoRestante -= Time.deltaTime;
        puntos = sistemaPuntos.puntuacion;

        if (tiempoRestante <= 60f)
        {
            textoCuentaAtras.color = Color.red;
            if (backgroundMusic != null)
            {
                if (musicaCambiada == false)
                {
                    CambiarMusica();
                }

            }
        }else{
            textoCuentaAtras.color = Color.white;
            if (backgroundMusic != null)
            {
                if (musicaCambiada == true)
                {
                    VolverMusica();
                }

            }


        }

        if (tiempoRestante <= 0f)
        {
            tiempoRestante = 0f;


            panelGameOver.SetActive(true);
            textoPuntos.GetComponentInChildren<TextMeshProUGUI>().SetText(puntos.ToString());
            ui.desactivado = false;
            Cursor.visible = true;
            Time.timeScale = 0;
        }

        ActualizarTextoCuentaAtras();
    }

    void ActualizarTextoCuentaAtras()
    {
        int minutos = Mathf.FloorToInt(tiempoRestante / 60);
        int segundos = Mathf.FloorToInt(tiempoRestante % 60);
        int decimas = Mathf.FloorToInt((tiempoRestante * 10) % 10);

        textoCuentaAtras.text = minutos.ToString("00") + "'" + segundos.ToString("00") + "\"" + decimas.ToString("0");


    }
    void CambiarMusica()
    {
        musicaCambiada = true;
        backgroundMusic.Stop();

        this.gameObject.GetComponent<AudioSource>().Play();

    }
    void VolverMusica(){
        musicaCambiada = false;
        this.gameObject.GetComponent<AudioSource>().Stop();
        backgroundMusic.Play();
    }
}


