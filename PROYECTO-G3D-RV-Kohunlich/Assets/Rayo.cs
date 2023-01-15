using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rayo : MonoBehaviour
{
    Vector3 vi, vf;
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
        //El movimiento del rayo depende de orientación y desplazamiento

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
            if (NombreLugar.text == "ACROPOLIS")
            {
                Info.text = "ACROPOLIS";
            }
            else if (NombreLugar.text == "CONJUNTO NOROESTE")
            {
                Info.text = "CONJUNTO NOROESTE";
            }
            else if (NombreLugar.text == "EDIFICIO DE LAS 11 PUERTAS")
            {
                Info.text = "EDIFICIO DE LAS 11 PUERTAS";
            }
            else if (NombreLugar.text == "EDIFICIO DE LAS COLUMNAS PARALELAS")
            {
                Info.text = "EDIFICIO DE LAS COLUMNAS PARALELAS";
            }
            else if (NombreLugar.text == "EL REY")
            {
                Info.text = "EL REY";
            }
            else if (NombreLugar.text == "ESTRUCTURAS PLAZA MERWIN")
            {
                Info.text = "ESTRUCTURAS PLAZA MERWIN";
            }
            else if (NombreLugar.text == "JUEGO DE PELOTA")
            {
                Info.text = "JUEGO DE PELOTA";
            }
            else if (NombreLugar.text == "LA GRADERÍA")
            {
                Info.text = "LA GRADERÍA";
            }
            else if (NombreLugar.text == "LOS 27 ESCALONES")
            {
                Info.text = "LOS 27 ESCALONES";
            }
            else if (NombreLugar.text == "MASCARONES")
            {
                Info.text = "MASCARONES";
            }
            else if (NombreLugar.text == "PALACIO DE LAS ESTELAS")
            {
                Info.text = "PALACIO DE LAS ESTELAS";
            }
            else if (NombreLugar.text == "PLAZA PIXA'AN")
            {
                Info.text = "PLAZA PIXA'AN";
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
