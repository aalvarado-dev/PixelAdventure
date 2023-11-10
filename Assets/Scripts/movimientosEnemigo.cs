using System.Collections.Generic;
using UnityEngine;

public class movimientosEnemigo : MonoBehaviour
{
    
    public List<Transform> puntosEspera; //variable que guarda el transform de los puntos que se moveran los enemigos
    public float velocidad = 2; //velocidad con la que se moveran 
    public float distanciaCambio = 0.2f; //variable que almacena el valor de la distancia con la que cambian de direccion
    byte siguientePos = 0; //variable que resetea las posiciones
    
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards( //actualizamos la posicion de los enemigos
            transform.position,//partimos del punto actual donde se encuentra
            puntosEspera[siguientePos].transform.position,//actualizamos la posicions a la siguiente de la lista de transforms
            velocidad * Time.deltaTime); //con la velocidad del sistema de nuestro pc

        if(Vector3.Distance(transform.position, //controlo cuando llega al siguiente punto
            puntosEspera[siguientePos].transform.position) < distanciaCambio) //cuando este serca de la distancia de cambio de dirrecion
        {
            siguientePos++;//sumamos un valor a la siguiente posicion      
            if(siguientePos >= puntosEspera.Count) //controlo cuando pasa por todos los puntos
            {
                siguientePos = 0; //reseteo los puntos de control por donde pasaran los enemigos o obstaculos.
            }
        }
        
    }
}
