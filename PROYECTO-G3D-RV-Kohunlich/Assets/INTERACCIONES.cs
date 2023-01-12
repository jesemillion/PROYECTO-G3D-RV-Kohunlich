using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class INTERACCIONES : MonoBehaviour
{
    int NT;
    Touch T0, T1;
    float dT0X, dT0Y, dT1X, dT1Y, RY = 0f, RX = 0f;
    public GameObject CAMARA;
    Vector2 Pi0, Pi1, Pf0, Pf1;
    float d;
    public Camera CAM;
    float EJEY = 1.8f;
    float EJEZ = 0f;
    float EJEX = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        EJEZ -= 1f * d * Mathf.Cos(RY * Mathf.Deg2Rad);
        EJEX -= 1f * d * Mathf.Sin(RY * Mathf.Deg2Rad);
        CAMARA.transform.localPosition = new Vector3(EJEX, EJEY, EJEZ);
    }
    void OnTriggerEnter(Collider other)
    {
        print("Ouch!");
        EJEZ -= 1f * d * Mathf.Cos(RY * Mathf.Deg2Rad);
        EJEX -= 1f * d * Mathf.Sin(RY * Mathf.Deg2Rad);
        CAMARA.transform.localPosition = new Vector3(EJEX, EJEY, EJEZ);
    }
    void Update()
    {
      
        EJEX = Mathf.Clamp(EJEX, -325f, 325f);
        EJEZ = Mathf.Clamp(EJEZ, -325f, 325f);
        RX = Mathf.Clamp(RX, -10f, 45f);

        NT = Input.touchCount;
        if (NT == 1)
        {
            T0 = Input.GetTouch(0);
            dT0X = T0.deltaPosition.x;
            dT0Y = T0.deltaPosition.y;
            if(Mathf.Abs(dT0X) > Mathf.Abs (dT0Y))
            {
                RY -= 0.1f * dT0X;
            }
            else
            {
                RX -= 0.1f * dT0Y;
            }
            
            CAMARA.transform.eulerAngles = new Vector3(RX, RY, 0f);

        }

        if (NT == 2)
        {
                MOVIMIENTO();
        }
        
    }
    void MOVIMIENTO()
    {
        dT0X = T0.deltaPosition.x;
        dT0Y = T0.deltaPosition.y;
        dT1X = T1.deltaPosition.x;
        dT1Y = T1.deltaPosition.y;
        T0 = Input.GetTouch(0);
        T1 = Input.GetTouch(1);
        Pf0 = T0.position;
        Pf1 = T1.position;
        Pi0 = Pf0 - T0.deltaPosition;
        Pi1 = Pf1 - T1.deltaPosition;
        d = (Pf0 - Pf1).magnitude - (Pi0 - Pi1).magnitude;

        if ((Mathf.Abs(dT0Y) > (Mathf.Abs(dT0X) * 1.2)) && (Mathf.Abs(dT1Y) > (Mathf.Abs(dT1X)) * 1.2) && d < 5 && d > -5)
        {
            //EJEY += 0.1f * (dT0Y+dT1Y)/2f;
            CAMARA.transform.position = new Vector3(EJEX, EJEY, EJEZ);
        }
        else if (d > 1.5 || d < -1.5)
        {
            EJEZ += 0.05f * d * Mathf.Cos(RY * Mathf.Deg2Rad);
            EJEX += 0.05f * d * Mathf.Sin(RY * Mathf.Deg2Rad);
            //EJEY += 0.1f * d * Mathf.Sin(-RX * Mathf.Deg2Rad);
            CAMARA.transform.localPosition = new Vector3(EJEX, EJEY, EJEZ);
        }
    }
}
