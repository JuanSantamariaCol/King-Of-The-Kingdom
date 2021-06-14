using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugadores : MonoBehaviour
{
    //Lineas para poder poner los controles a cada jugador
    public KeyCode Arriba;
    public KeyCode Abajo;
    public KeyCode Izquierda;
    public KeyCode Derecha;

    //Frenar los movimientos en el sentido contrario 
    bool Vertical = true;
    bool Horizontal = true;
    public float velocidad = 20f;

    //seleccionar un objeto 
    public GameObject Muros;


    /// <summary>
    /// IMPORTANTEEEEEEEEEEEEEEEEE MIRARRRR LA DIRECCIONNN DE ARRANQUEEEEEEEEE
    /// </summary>



    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * velocidad;
        Vertical = false;
        Horizontal = true;
        Crear_Muro();


    }

    // Update is called once per frame
    void Update()
    {
        
        //si detecta que se preciono la tecla cambie el vector para la direccion determinada 

        if ((Input.GetKeyDown(Arriba)) &  Vertical )
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
        else if ((Input.GetKeyDown(Derecha)) & Horizontal )
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Muro"))
        {
            Destroy(gameObject);
            Debug.Log("Murio");
        }
        if (collision.CompareTag("Limite"))
        {
            Debug.Log("entro");
            Destroy(gameObject);
        }

    }
 
    
}

