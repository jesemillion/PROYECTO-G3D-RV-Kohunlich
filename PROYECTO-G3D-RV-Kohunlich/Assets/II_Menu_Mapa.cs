using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

// Instituto Politécnico Nacional - UPIITA
// Realidad Virtual - 4MV14
// Proyecto Final 2023-1
// Equipo: Interacciones e Información
// Integrantes:
//  - Hinojosa Pérez Marco Antonio
//  - Mancilla Galván Luis Ángel
//  - Morales Flores Luis Fernando
//  - Velasco Sandoval Nahomi

public class II_Menu_Mapa : MonoBehaviour
{
    public Canvas Principal;
    public Canvas Menu;
    public Canvas Mapa;
    public Canvas Video;
    public Button Btn_Menu;
    public Button Btn_Tutorial;
    public Button Btn_Modo;
    public Button Btn_Ok;
    public Button Btn_Salir;
    public Button Btn_Mapa;
    public Button Btn_Volver;
    public Dropdown Dd_Modo;
    //public GameObject INTRO;
    public Button ZONA1;
    public Button ZONA2;
    public Button ZONA3;
    public Button ZONA4;
    public Button ZONA5;
    public Button ZONA6;
    public Button ZONA7;
    public Button ZONA8;
    public Button ZONA9;
    public Button ZONA10;
    public Button ZONA11;
    public Button ZONA12;
    public Button ZONA13;
    public GameObject CAMERA;
    public VideoPlayer INTRO;
    // Start is called before the first frame update
    void CheckOver(VideoPlayer vp)
    {
        //gameObject.SetActive(false);
        Video.enabled = false;
        Principal.enabled = true;
    }
    void Start()
    {
        Principal.enabled = false;
        Menu.enabled = false;
        Mapa.enabled = false;
        //video = INTRO.GetComponent<VideoPlayer>();
        INTRO.Play();
        INTRO.loopPointReached += CheckOver;
    }

    // Update is called once per frame
    void Update()
    {
        Btn_Menu.onClick.AddListener(Btn_Menu_clicked);
        Btn_Modo.onClick.AddListener(Btn_Modo_clicked);
        Btn_Ok.onClick.AddListener(Btn_Ok_clicked);
        Btn_Salir.onClick.AddListener(Btn_salir_clicked);
        Btn_Tutorial.onClick.AddListener(Btn_Tutorial_clicked);
        Btn_Mapa.onClick.AddListener(Btn_Modo_Mapa_clicked);
        Btn_Volver.onClick.AddListener(Btn_Volver_clicked);
        ZONA1.onClick.AddListener(Btn_ZONA1_clicked);
        ZONA2.onClick.AddListener(Btn_ZONA2_clicked);
        ZONA3.onClick.AddListener(Btn_ZONA3_clicked);
        ZONA4.onClick.AddListener(Btn_ZONA4_clicked);
        ZONA5.onClick.AddListener(Btn_ZONA5_clicked);
        ZONA6.onClick.AddListener(Btn_ZONA6_clicked);
        ZONA7.onClick.AddListener(Btn_ZONA7_clicked);
        ZONA8.onClick.AddListener(Btn_ZONA8_clicked);
        ZONA9.onClick.AddListener(Btn_ZONA9_clicked);
        ZONA10.onClick.AddListener(Btn_ZONA10_clicked);
        ZONA11.onClick.AddListener(Btn_ZONA11_clicked);
        ZONA12.onClick.AddListener(Btn_ZONA12_clicked);
        ZONA13.onClick.AddListener(Btn_ZONA13_clicked);
    }

    private void Btn_Menu_clicked()
    {
        Menu.enabled = true;
        Mapa.enabled = false;
        Principal.enabled = false;

        Btn_Ok.gameObject.SetActive(false);
        Dd_Modo.gameObject.SetActive(false);
    }
    private void Btn_Modo_clicked()
    {
        Btn_Tutorial.gameObject.SetActive(false);
        Btn_Salir.gameObject.SetActive(false);
        Btn_Ok.gameObject.SetActive(true);
        Dd_Modo.gameObject.SetActive(true);
        Btn_Modo.gameObject.SetActive(false);
    }
    private void Btn_Ok_clicked()
    {

        Btn_Ok.gameObject.SetActive(false);
        Dd_Modo.gameObject.SetActive(false);
        Btn_Tutorial.gameObject.SetActive(true);
        Btn_Salir.gameObject.SetActive(true);
        Btn_Modo.gameObject.SetActive(true);
    }
    private void Btn_salir_clicked() {

        Menu.enabled = false;
        Principal.enabled = true;
        Mapa.enabled = false;
    }
    private void Btn_Tutorial_clicked() {

    }
    private void Btn_Modo_Mapa_clicked() {
        Menu.enabled = false;
        Principal.enabled = false;
        Mapa.enabled = true;
    }
    private void Btn_Volver_clicked() {
        Menu.enabled = false;
        Principal.enabled = true;
        Mapa.enabled = false;
    }
    private void Btn_ZONA1_clicked()
    {
        Menu.enabled = false;
        Principal.enabled = true;
        Mapa.enabled = false;
        CAMERA.transform.position = new Vector3(-2400f, 215f, -600f);
    }
    private void Btn_ZONA2_clicked()
    {
        Menu.enabled = false;
        Principal.enabled = true;
        Mapa.enabled = false;
        CAMERA.transform.position = new Vector3(-2100f, 215f, -600f);

    }
    private void Btn_ZONA3_clicked()
    {
        Menu.enabled = false;
        Principal.enabled = true;
        Mapa.enabled = false;
        CAMERA.transform.position = new Vector3(-1800f, 215f, -600f);
    }
    private void Btn_ZONA4_clicked()
    {
        Menu.enabled = false;
        Principal.enabled = true;
        Mapa.enabled = false;
        CAMERA.transform.position = new Vector3(-1500f, 215f, -600f);
    }
    private void Btn_ZONA5_clicked()
    {
        Menu.enabled = false;
        Principal.enabled = true;
        Mapa.enabled = false;
        CAMERA.transform.position = new Vector3(-1200f, 215f, -600f);
    }
    private void Btn_ZONA6_clicked()
    {
        Menu.enabled = false;
        Principal.enabled = true;
        Mapa.enabled = false;
        CAMERA.transform.position = new Vector3(-900f, 215f, -600f);

    }
    private void Btn_ZONA7_clicked()
    {
        Menu.enabled = false;
        Principal.enabled = true;
        Mapa.enabled = false;
        CAMERA.transform.position = new Vector3(-600f, 215f, -600f);
    }
    private void Btn_ZONA8_clicked()
    {
        Menu.enabled = false;
        Principal.enabled = true;
        Mapa.enabled = false;
        CAMERA.transform.position = new Vector3(-300f, 215f, -600f);
    }
    private void Btn_ZONA9_clicked()
    {
        Menu.enabled = false;
        Principal.enabled = true;
        Mapa.enabled = false;
        CAMERA.transform.position = new Vector3(300f, 215f, -600f);
    }
    private void Btn_ZONA10_clicked()
    {
        Menu.enabled = false;
        Principal.enabled = true;
        Mapa.enabled = false;
        CAMERA.transform.position = new Vector3(600f, 215f, -600f);

    }
    private void Btn_ZONA11_clicked()
    {
        Menu.enabled = false;
        Principal.enabled = true;
        Mapa.enabled = false;
        CAMERA.transform.position = new Vector3(900f, 215f, -600f);
    }
    private void Btn_ZONA12_clicked()
    {
        Menu.enabled = false;
        Principal.enabled = true;
        Mapa.enabled = false;
        CAMERA.transform.position = new Vector3(1200f, 215f, -600f);
    }
    private void Btn_ZONA13_clicked()
    {
        Menu.enabled = false;
        Principal.enabled = true;
        Mapa.enabled = false;
        CAMERA.transform.position = new Vector3(1500f, 215f, -600f);
    } 
}
