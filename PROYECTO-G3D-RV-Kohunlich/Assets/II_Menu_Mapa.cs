using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Button Btn_Menu;
    public Button Btn_Tutorial;
    public Button Btn_RealidadAumentada;
    public Button Btn_Modo;
    public Button Btn_Ok;
    public Button Btn_Salir;
    public Button Btn_Mapa;
    public Button Btn_Volver;
    public Dropdown Dd_Modo;
    // Start is called before the first frame update
    void Start()
    {
        Menu.enabled = false;
        Mapa.enabled = false;
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
    }

    private void Btn_Menu_clicked()
    {
        Menu.enabled = true;
        Mapa.enabled = false;
        Principal.enabled = false;
        Btn_RealidadAumentada.gameObject.SetActive(false);
       
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
}
