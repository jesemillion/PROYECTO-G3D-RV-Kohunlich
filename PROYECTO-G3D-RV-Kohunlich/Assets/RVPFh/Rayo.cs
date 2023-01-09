using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rayo : MonoBehaviour
{
    Vector3 vi, vf;
    float t;
    Quaternion Q0;
    Ray RAYO;
    public Text NombreLugar, Info;
    RaycastHit GOLPE;
    public GameObject CAM;
    public Button B_Info;
    bool Activar;

    // Start is called before the first frame update
    void Start()
    {
        Activar = false;
        Info.gameObject.SetActive(false);
        vf = new Vector3(0f, 0.5f, 1000f);
    }

    // Update is called once per frame
    void Update()
    {
       
        vi = CAM.transform.position;
        //Provisional para probar la colision del rayo
        //El movimiento del rayo depende de orientaci�n y desplazamiento

        Q0 = CAM.transform.rotation;
        RAYO = new Ray(vi, Q0 * vf);
        Physics.Raycast(RAYO, out GOLPE);
        CAM.transform.rotation = Q0;
        Debug.DrawRay(vi, Q0 * vf);
        if (GOLPE.collider && !GOLPE.collider.CompareTag("Untagged"))
        {
            NombreLugar.text = GOLPE.collider.tag;
            B_Info.gameObject.SetActive(true);
            //Esqueleto nombre tag
            if (NombreLugar.text == "CUBOPRUEBA")
                {
                    Info.text = "Esto es un cubo";
                }
            else if (NombreLugar.text == "CILINDRO")
                {
                    Info.text = "Esto es un cilindro";
                }
            else
                {
                    Info.text = " ";
                }
          
        }
        else
        {
            NombreLugar.text = " ";
            Info.gameObject.SetActive(false);
            B_Info.gameObject.SetActive(false);
            Activar = false;
        }
    }
    
    public void B_Info_clicked()
    {
        Activar = !Activar;
        if (Activar) Info.gameObject.SetActive(true);
        else Info.gameObject.SetActive(false);
    }
    
}
