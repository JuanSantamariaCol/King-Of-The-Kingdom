using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GuardadorPuntajes : MonoBehaviour
{
    //objeto Destruir
    public GameObject PoderDestruir;
    public float TiempoRes = 60;
    public int Radius = 40;

    //Texto Ganador
    public GameObject Ventana;
    public Text Ganador;
    public Image ImagenGanador;


    //Jugador Rojo
    public Sprite ImgRojo;
    public JugadorRojoTeams JRojo;
    private bool RVivo;
    private int PRojo;
    private int ContR = 0;
    //Jugador Azul
    public Sprite ImgAzul;
    public JugadorAzulTeams JAzul;
    private bool AVivo;
    private int PAzul;
    private int ContA = 0;
    //Jugador Verde
    public Sprite ImgVerde;
    public JugadorVerdeTeams JVerde;
    private bool VVivo;
    private int PVerde;
    private int ContV = 0;
    //Jugador Morado
    public Sprite ImgMorado;
    public JugadorMoradoTeams JMorado;
    private bool MVivo;
    private int PMorado;
    private int ContM = 0;
    




    // Start is called before the first frame update
    void Start()
    {
        //Para Reinicar Puntuaciones 
        //PlayerPrefs.SetInt("PRojo", 0);
        //PlayerPrefs.SetInt("PAzul", 0);
        //PlayerPrefs.SetInt("PVerde", 0);
        //PlayerPrefs.SetInt("PMorado", 0);

        PRojo = PlayerPrefs.GetInt("PRojo"); //Si no se le da valor toma 0 
        PAzul = PlayerPrefs.GetInt("PAzul");
        PVerde = PlayerPrefs.GetInt("PVerde");
        PMorado = PlayerPrefs.GetInt("PMorado");

        //Sacar Puntuaciones de el archivo guardado 

    }

    // Update is called once per frame
    void Update()
    {
        TiempoRes -= Time.deltaTime;
        var randWithinCircle1 = Random.insideUnitCircle * Radius;
        print(randWithinCircle1);
        if (TiempoRes < 0)
        {
            GameObject Pw = (GameObject)Instantiate(PoderDestruir,(randWithinCircle1), Quaternion.identity);
            TiempoRes = 40;
        }



        //Jugador Rojo
        RVivo = JRojo.Vivo;
        if (ContR == 0)
        {
            if (RVivo == false)
            {
                PRojo+= JRojo.Puntos ;
                ContR++;
                //Guardarlo Falta
            }

        }
        //Jugador Azul
        AVivo = JAzul.Vivo;
        if (ContA == 0)
        {
            if(AVivo == false)
            {
                PAzul += JAzul.Puntos;
                ContA++;
                //Guardarlo Falta
            }
        }

        // Jugador Verde
        VVivo = JVerde.Vivo;
        if (ContV == 0)
        {
            if (VVivo == false)
            {
                PVerde += JVerde.Puntos;
                ContV++;
                //Guardarlo Falta
            }
        }
        //Jugador Morado
        MVivo = JMorado.Vivo;
        if (ContM == 0)
        {
            if (MVivo == false)
            {
                PMorado += JMorado.Puntos;
                ContM++;
                //Guardarlo Falta
            }
        }




        //Definir Ganador
        if ((RVivo == true) && ((AVivo || VVivo || MVivo) == false))
        {
            Ventana.gameObject.SetActive(true);
            Ganador.text = "Alma Roja";
            ImagenGanador.sprite = ImgRojo;
        }

        if ((AVivo == true) && ((RVivo || VVivo || MVivo) == false))
        {
            Ventana.gameObject.SetActive(true);
            Ganador.text = "Alma Azul";
            ImagenGanador.sprite = ImgAzul;
        }

        if ((VVivo == true) && ((RVivo || AVivo || MVivo) == false))
        {
            Ventana.gameObject.SetActive(true);
            Ganador.text = "Alma Verde";
            ImagenGanador.sprite = ImgVerde;
        }

        if ((MVivo == true) && ((RVivo || VVivo || AVivo) == false))
        {
            Ventana.gameObject.SetActive(true);
            Ganador.text = "Alma Morada";
            ImagenGanador.sprite = ImgMorado;
        }


        //Guardar Puntajes 
        PlayerPrefs.SetInt("PRojo", PRojo);
        PlayerPrefs.SetInt("PAzul", PAzul);
        PlayerPrefs.SetInt("PVerde", PVerde);
        PlayerPrefs.SetInt("PMorado", PMorado);

        //print(PRojo);
        //print(PAzul);
        //print(PVerde);
        //print(PMorado);
        
    }
}
