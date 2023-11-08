using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientosEnemigo : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Transform> puntosEspera;
    public float velocidad = 2;
    public float distanciaCambio = 0.2f;
    byte siguientePos = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            puntosEspera[siguientePos].transform.position,
            velocidad * Time.deltaTime);

        if(Vector3.Distance(transform.position,
            puntosEspera[siguientePos].transform.position) < distanciaCambio)
        {
            siguientePos++;            
            if(siguientePos >= puntosEspera.Count)
            {
                siguientePos = 0;
            }
        }
        
    }
}
