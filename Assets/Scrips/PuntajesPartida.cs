using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuntajesPartida : MonoBehaviour
{
    private int PRojo;
    private int PAzul;
    private int PVerde;
    private int PMorado;
    public Text Rojo;
    public Text Azul;
    public Text Verde;
    public Text Morado;



    // Start is called before the first frame update
    void Start()
    {
        string PuntajeRojo = PlayerPrefs.GetInt("PRojo").ToString();
        string PuntajeAzul = PlayerPrefs.GetInt("PAzul").ToString();
        string PuntajeVerde = PlayerPrefs.GetInt("PVerde").ToString();
        string PuntajeMorado = PlayerPrefs.GetInt("PMorado").ToString();

        Rojo.text = PuntajeRojo;
        Azul.text = PuntajeAzul;
        Verde.text = PuntajeVerde;
        Morado.text = PuntajeMorado;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
