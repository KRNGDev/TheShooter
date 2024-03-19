using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProyectoTank.Camaras
{
    public class TopDownCamara : MonoBehaviour
    {
        #region Variables
        private Transform m_target;
        public float m_Altura = 10f;
        public float m_Distancia = 20f;
        public float m_Angulo = 45f;
        public float m_SmoothSpeed = 1f;

        public GameObject canvas;
        //public ProyectoTank.MenuInicio.MenuPrincipal canvas;

        public Vector3 VelReferencia;

        public UIScript ui;

        #endregion



        #region Main Metodos
        // Start is called before the first frame update
        void Awake()
        {

            // StartCoroutine("Tiempo");           
            m_target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();


        }

        // Update is called once per frame
        void FixedUpdate()
        {


            if (ui.desactivado)
            {
                ManejoCamara();
            }

        }
        #endregion


        #region Metodos auxiliares
        protected void ManejoCamara()
        {
            if (!m_target)
            {
                return;
            }/*
            //Construir el vector de posicion Mundial
            Vector3 worldPosition = (Vector3.forward * -m_Distancia) + (Vector3.up * m_Altura);
            //Debug.DrawLine(m_target.position, worldPosition, Color.red);

            //Construir nuestro vector de rotacion
            Quaternion playerRotation = m_target.rotation;
            float playerAngle = Quaternion.Angle(Quaternion.identity, playerRotation);
            
            Vector3 rotatedVector = Quaternion.AngleAxis(m_Angulo, Vector3.up)* worldPosition;
           // Debug.DrawLine(m_target.position, rotatedVector, Color.green);

            //Mover Nuestra posicion
            Vector3 flatTargetPosition = m_target.position;
            
            //flatTargetPosition.y = 0f;
            Vector3 finalPosition = flatTargetPosition + rotatedVector;
            //Debug.DrawLine(m_target.position, finalPosition, Color.blue);

            transform.position = Vector3.SmoothDamp(transform.position,finalPosition, ref VelReferencia, m_SmoothSpeed) ;
            
            
            transform.LookAt(flatTargetPosition);*/

            // Obtenemos la rotación actual del jugador
            Quaternion playerRotation = m_target.rotation;

            // Rotamos la posición de la cámara respecto a la rotación del jugador
            Vector3 cameraOffset = playerRotation * new Vector3(0, -m_Altura, -m_Distancia);

            // Calculamos la posición final de la cámara
            Vector3 finalPosition = m_target.position + cameraOffset;

            // Actualizamos la posición de la cámara suavemente
            transform.position = Vector3.SmoothDamp(transform.position, finalPosition, ref VelReferencia, m_SmoothSpeed);

            // Hacemos que la cámara mire hacia donde mira el jugador
            transform.LookAt(m_target.position + m_target.forward * 2); // Ajusta el multiplicador según tu escala de mundo



        }
        IEnumerator Tiempo()
        {


            yield return new WaitForSeconds(3.5F);


            //canvas = GameObject.FindGameObjectWithTag("Panel Opciones").GetComponent<ProyectoTank.MenuInicio.MenuPrincipal>();
            ManejoCamara();
            canvas.SetActive(true);

        }
        #endregion
    }
}
