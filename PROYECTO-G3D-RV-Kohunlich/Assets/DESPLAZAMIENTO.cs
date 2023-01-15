using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DESPLAZAMIENTO : MonoBehaviour
{
    int NT;
    Touch T0, T1;
    float dT0X, dT0Y;
    public float RY = 0f, RX = 0f;
    Vector2 Pi0, Pi1, Pf0, Pf1;
    public CharacterController CONTROLLER;
    public GameObject CAM;
    Vector3 camForward;
    Vector3 moveCONTROLLER;
    float d;

    float boundary = 325f; //MODIFICAR AQUI EL TAMAÑO DEL CUADRADO EN EL 
                           //CUAL EL USUARIO SE PUEDE DESPLAZAR, +-325 
    float vel = 5f; //MODIFICAR AQUI LA VELOCIDAD DEL DESPLAZAMIENTO

    int Mod;//VARIABLE QUE DEFINE ENTRE MUNDO VIRTUAL Y REALIDAD VIRTUAL
    float Laf, Lof;
    //float Lai = 19.511446f, Loi = -99.126563f, Ali = 2241f; //ESCUELA
    float Lai = 19.40977f, Loi = -99.01373f, Ali = 2228f; //PERSONAL
    float dLa, dLo, X, Z, t;
    float R = 6371000f;
    Quaternion Q0, Q1, Q2, Q3, QA, QB;
    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
        Q1 = new Quaternion(0f, 0f, Mathf.Sin(Mathf.PI / 4f), Mathf.Cos(Mathf.PI / 4f));
        Q2 = new Quaternion(Mathf.Sin(Mathf.PI / 4f), 0f, 0f, Mathf.Cos(Mathf.PI / 4f));
        Q3 = new Quaternion(0f, 0f, Mathf.Sin(Mathf.PI / 2f), Mathf.Cos(Mathf.PI / 2f));
    }

    // Update is called once per frame
    void Update()
    {   
        if (Mod == 0)
        {
                RV();
        }
        else
        {
            RA();
        }
    }
    public void MODO(Dropdown dropdown)
    {
        Mod = dropdown.value;
    }
    void RV()
    {
        //Limite para mirar arriba y abajo, desde -5° hasta 30°
        RX = Mathf.Clamp(RX, -45f, 25f);
        NT = Input.touchCount;
        if (NT == 1)
        {
            T0 = Input.GetTouch(0);
            dT0X = T0.deltaPosition.x;
            dT0Y = T0.deltaPosition.y;
            //ROTACION DE CAMARA VERTICALMENTE
            if (Mathf.Abs(dT0X) > Mathf.Abs(dT0Y))
            {
                RY -= 0.1f * dT0X;
            }
            //ROTACION DE CAMARA HORIZONTALMENTE
            else
            {
                RX -= 0.1f * dT0Y;
            }
            //Actualizacion del angulo de vision
            CAM.transform.eulerAngles = new Vector3(RX, RY, 0f);
            t = Time.time;
        }
        //DESPLAZAMIENTO
        if (NT == 2)
        {
            T0 = Input.GetTouch(0);
            T1 = Input.GetTouch(1);
            Pf0 = T0.position;
            Pf1 = T1.position;
            Pi0 = Pf0 - T0.deltaPosition;
            Pi1 = Pf1 - T1.deltaPosition;
            d = (Pf0 - Pf1).magnitude - (Pi0 - Pi1).magnitude;
            if (d > 1.5 || d < -1.5)
            {
                //Obtenemos hacia donde esta mirando la camara
                //solo la componente horizontal
                camForward = CAM.transform.forward;
                camForward.y = 0;
                //Normalizamos la direccion
                camForward = camForward.normalized;

                //El movimiento se realiza mediante el producto
                //de la magnitud del gesto realizado por el usuario
                //y la direccion hacia donde mira la camara
                moveCONTROLLER = d * camForward;

                //Se realiza el desplazamiento
                CONTROLLER.Move(moveCONTROLLER * Time.deltaTime * vel);

                //DEFINMOS LAS FRONTERAS DEL DESPLAZAMIENTO MIN -325 MAX 325 EN X y Y
                if (CONTROLLER.transform.localPosition[0] > boundary)
                {
                    CONTROLLER.transform.localPosition = new Vector3(boundary - 1, 1.8f, CONTROLLER.transform.localPosition[2]);
                }
                else if (CONTROLLER.transform.localPosition[0] < -boundary)
                {
                    CONTROLLER.transform.localPosition = new Vector3(-boundary + 1, 1.8f, CONTROLLER.transform.localPosition[2]);
                }
                if (CONTROLLER.transform.localPosition[2] > boundary)
                {
                    CONTROLLER.transform.localPosition = new Vector3(CONTROLLER.transform.localPosition[0], 1.8f, boundary - 1);
                }
                else if (CONTROLLER.transform.localPosition[2] < -boundary)
                {
                    CONTROLLER.transform.localPosition = new Vector3(CONTROLLER.transform.localPosition[0], 1.8f, -boundary + 1);
                }
            }
        }
    }
    void RA()
    {
        if (Time.time < (t + 3f))
        {
            Input.location.Start();
        }
        else
        {
            Q0 = Input.gyro.attitude;
            QA = Q3 * Q2 * Q1 * Q0;
            QB = QA;
            QB.x = -QA.x;
            QB.y = -QA.y;
            CAM.transform.rotation = QB;
            Laf = Input.location.lastData.latitude;
            Lof = Input.location.lastData.longitude;
            dLa = Laf - Lai;
            dLo = Lof - Loi;
            X = R * (dLo * Mathf.Deg2Rad) * Mathf.Cos(Laf * Mathf.Deg2Rad);
            Z = R * dLa * Mathf.Deg2Rad;
            CONTROLLER.transform.position = new Vector3(X, 1.8f, Z);
        }
    }
}
