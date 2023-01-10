using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TOUCH : MonoBehaviour
{
    int NT;
    Touch T0, T1;
    float dT0x, dT0y, dT1x, dT1y, RY = 0, RX = 0, H = 1.8f;
    int a;
    public GameObject CAMARA;
    Vector2 PI0, PI1, PF0, PF1;
    float d, di, df;
    public Camera CAM;
    float FV = 60f;

    float Ax = -52.9f, Az = -80.6f;

    // public Text TNT1, TNT2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        NT = Input.touchCount;
        if(NT == 1)
        {
            T0 = Input.GetTouch(0);
            dT0x = T0.deltaPosition.x;
            dT0y = T0.deltaPosition.y;
            if(Mathf.Abs(dT0x) > Mathf.Abs(dT0y))
            {
                RY -= 0.1f * dT0x;
            }
            else
            {
                RX += 0.1f * dT0y;
            }
            
            
            CAMARA.transform.eulerAngles = new Vector3(RX, RY, 0f);
            Debug.Log(dT0x.ToString() + "  "+ dT0y.ToString());
            Debug.Log("a");
        }
        if(NT == 2)
        {
            T0 = Input.GetTouch(0);
            T1 = Input.GetTouch(1);
            PF0 = T0.position;
            PF1 = T1.position;
            PI0 = PF0 - T0.deltaPosition;
            PI1 = PF1 - T1.deltaPosition;
            
            dT0x = T0.deltaPosition.x;
            dT0y = T0.deltaPosition.y;
            dT1x = T1.deltaPosition.x;
            dT1y = T1.deltaPosition.y;

            d = (PF0-PF1).magnitude - (PI0 - PI1).magnitude;


            if (Mathf.Abs(d) > Mathf.Abs(dT0y))
            {
                //FV -= 0.1f * d;
                //FV = Mathf.Clamp(FV, 8f, 128f);
                //CAM.fieldOfView = FV;
                Az += d * 0.07f * Mathf.Cos(Mathf.Deg2Rad * RY);
                Ax += d * 0.07f * Mathf.Sin(Mathf.Deg2Rad * RY);
                CAMARA.transform.position = new Vector3(Ax, 1.8f, Az);
                //CAMARA.transform.position = new Vector3(Ax, H, Az);
            }
            else
            {
            H += 0.1f*dT0y;
            H = Mathf.Clamp(H, 1.8f, 100f);
            CAMARA.transform.position = new Vector3(Ax, 1.8f, Az);
            //CAMARA.transform.position = new Vector3(Ax, H, Az);
            } 

            

           

           // TNT1.text = dT0y.ToString();
            //TNT2.text = d.ToString();
            Debug.Log(PF0.ToString());
        }
    }
}
