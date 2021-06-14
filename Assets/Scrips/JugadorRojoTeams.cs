using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorRojoTeams : MonoBehaviour
{
    //Lineas para poder poner los controles a cada jugador
    public KeyCode Arriba;
    public KeyCode Abajo;
    public KeyCode Izquierda;
    public KeyCode Derecha;
    public KeyCode Poder;

    //Frenar los movimientos en el sentido contrario 
    public bool Vivo = true;   //accionador para puntos y destruccion de muros y si mismo
    bool Vertical = true;
    bool Horizontal = true;
    bool Precionar = false; //Tecla para Activar El Poder
    bool Activador = false;
    public float velocidad = 6f;
    public float DuracionPoder = 3;

    public int Puntos = 0;

    //GameObjects (Muerte,Corona,Muros)
    public GameObject Muerte;
    public GameObject Corona;
    public GameObject Muros;
    public GameObject ImgPoder;

    /// <summary>
    /// IMPORTANTEEEEEEEEEEEEEEEEE MIRARRRR LA DIRECCIONNN DE ARRANQUEEEEEEEEE
    /// </summary>



    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * velocidad;
        ImgPoder.gameObject.SetActive(true);
        Vertical = true;
        Horizontal = false;
        Muerte.gameObject.SetActive(false);
        Crear_Muro();


    }

    // Update is called once per frame
    void Update()
    {
        if (Vivo == false) //condicional para determinar si esta vivo o no 
        {

            //mandar señal al otro script
            //lo de el puntaje arriba
            DestruirMuro("MuroRojo"); //CAMBIAR PARA CADA JUGADOR 
            Destroy(gameObject); //destruye el Objeto por eso se pone de ultimas para que ejecute todo

        }
        if (Vivo == true)
        {
            Puntos++;

        }
        //POOOOOOOOOOOOOOOOOOOOOOOOOOODEEEEEEEEEEEEEEEEEERRRRRRRRRRRRRR
        //ver si el poder esta disponib
        if (Activador == false)
        {
            ImgPoder.gameObject.SetActive(true);
        }

        if (Activador == true)
        {
            ImgPoder.gameObject.SetActive(false);

        }
        //Tecla para activar el poder
        if (Input.GetKeyDown(Poder))
        {
            Precionar = true;
        }

        //condicional Para Poder Listo
        if ((DuracionPoder <= 3) && Precionar)
        {
            velocidad = 15;
            DuracionPoder -= Time.deltaTime;
        }

        //Condicional Para Cargar Poder
        if ((DuracionPoder!=3)&& Activador)
        {
            Precionar = false;
            DuracionPoder += Time.deltaTime;
        }

        //Condicion Para Que Deje De Sumar Tiempo De Carga
        if (DuracionPoder >= 3)
        {
            DuracionPoder = 3;
            Activador = false;
        }

        //condicional Para Que Entre En LA Suma Y Salga de la Resta
        if (DuracionPoder < 0)
        {
            velocidad = 6;
            Activador = true;
            Precionar = false;
        }



        //si detecta que se preciono la tecla cambie el vector para la direccion determinada 

        if ((Input.GetKeyDown(Arriba)) & Vertical)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * velocidad;
            GetComponent<Rigidbody2D>().rotation = 0;
            //parte para que los jugadores no se puedan devolver en el sentido contrario 
            Vertical = false;
            Horizontal = true;
            Crear_Muro();
        }
        else if ((Input.GetKeyDown(Abajo)) & Vertical)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.down * velocidad;
            GetComponent<Rigidbody2D>().rotation = 180;
            Vertical = false;
            Horizontal = true;
            Crear_Muro();
        }
        else if ((Input.GetKeyDown(Izquierda)) & Horizontal)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.left * velocidad;
            GetComponent<Rigidbody2D>().rotation = 90;
            Horizontal = false;
            Vertical = true;
            Crear_Muro();
        }
        else if ((Input.GetKeyDown(Derecha)) & Horizontal)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.right * velocidad;
            GetComponent<Rigidbody2D>().rotation = -90;
            Horizontal = false;
            Vertical = true;
            Crear_Muro();
        }
        Crear_Muro();
    }


    void Crear_Muro()
    {

        GameObject Muro = (GameObject)Instantiate(Muros, transform.position, Quaternion.identity);


    }
    // Destruccion de el jugador (GameObject)___________________________________
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //para chocar con el otro team 
        if (collision.CompareTag("MuroVerde"))
        {
            Corona.gameObject.SetActive(false);
            Muerte.gameObject.SetActive(true);
            Vivo = false;

        }

        if (collision.CompareTag("MuroMorado"))
        {
            Corona.gameObject.SetActive(false);
            Muerte.gameObject.SetActive(true);
            Vivo = false;

        }

        if (collision.CompareTag("MuroAzul"))
        {
            Corona.gameObject.SetActive(false);
            Muerte.gameObject.SetActive(true);
            Vivo = false;

        }
        //para chocar con si mismo 
        if (collision.CompareTag("MuroRojo"))
        {
            Corona.gameObject.SetActive(false);
            Muerte.gameObject.SetActive(true);
            Vivo = false;

        }

        if (collision.CompareTag("Limite"))
        {
            Corona.gameObject.SetActive(false);
            Muerte.gameObject.SetActive(true);
            Vivo = false;


        }

        if (collision.CompareTag("PoderDestruir"))
        {
            Destroy(collision.gameObject);
            DestruirMuro("MuroMorado");
            DestruirMuro("MuroAzul");
            DestruirMuro("MuroVerde");

        }

    }
    
    public void DestruirMuro(string tag) //funcion para buscar muro y destruirlos
    {

        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);
        foreach(GameObject target in gameObjects) // foreach (hacer algo para cada elemento de la lista )
        {
            GameObject.Destroy(target);
        }
    }
}
