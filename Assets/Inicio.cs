using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inicio : MonoBehaviour
{
    public void Jugar()//funcion para el boton para empezar a jugar
    {
        SceneManager.LoadScene(1);//cargo la escena de juego
    }
}
