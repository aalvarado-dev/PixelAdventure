using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMov : MonoBehaviour
{
    Rigidbody2D myRB; //variable que almacena el rigibodi del jugador
    private Animator animator; //Para capturar los componentes del Animator del Jugador
    public TextMeshProUGUI puntos; //variable que mustra los puntos por pantalla
    int points = 0; //vriable que controla los puntos de la partida
    public AudioSource coin; //sonido que se reproduce al coger las monedas

    public float maxSpeed; //velocidad maxima con la que se movera el jugador
    SpriteRenderer myrenderer; //variable que almacena el render del jugador
    bool facingRight = true; //variable que controla cuando el jugador mira a la derecha 
    bool isJumping = false; //variable que controla si el jugador esta saltando
    [Range(1, 500)] public float potenciaSalto; //variable que controla la potencia de salto del jugador

    private void Start()
    {
        myRB = GetComponent<Rigidbody2D>(); //guardo el rgb del jugador
        myrenderer = GetComponent<SpriteRenderer>(); //guardo el spriterender del jugador

        
        animator = GetComponent<Animator>();//guardo el animator del jugador
    }
    private void FixedUpdate()
    {
        
        if (Input.GetButton("Jump") && !isJumping)//Si pulso la tecla de salto espacio y no esta saltando
        {
            
            myRB.AddForce(Vector2.up * potenciaSalto);//Le aplico la fuerza de salto multiplicado por la potencia de salto           
            isJumping = true; //Digo que esta saltando para que no pueda volver a saltar   
            animator.SetBool("isJump", true);//asigno a la variable creada en el animator a true para que el jugador canvie la animacion a la de salto
        }
    }

    private void Update()
    {
        float move = Input.GetAxis("Horizontal"); //almaceno en la variable las teclas a o d o las flechas derecha izquierda

        if (move > 0 && !facingRight) //si el moviemiento entrado es mayor a 0 y no esta mirando a la derecha
        {
            Flip(); //llamo a la funcion para que gire al jugador
        }
        else if (move < 0 && facingRight) //si el moviemiento entrado es menor a 0 y no esta mirando a la derecha
        {
            Flip();//llamo a la funcion para que gire al jugador
        }
        myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y); //con la variable creada antes del rgb le damos movimiento al personaje 
        animator.SetFloat("MoveSpeed", Mathf.Abs(move)); //asigno a la variable animator movespeed para que el jugador pase a correr pasandole el movimiento sin valores negativos 
    }
    void Flip() // funcion que gira al jugador
    {
        facingRight = !facingRight; //si esta mirando a la derecha asignamos que no esta mirando
        myrenderer.flipX = !myrenderer.flipX;//asignamos el movimiento con flip x para poder girara al jugador hacia la direccion que se mueve
    }
    private void OnCollisionEnter2D(Collision2D collision) //controlo las colisiones en el juego con el jugador
    {
        if (collision.gameObject.CompareTag("Ground")) // si colisionamos con el suelo
        {
            //Digo que no esta saltando para que pueda volver a saltar
            isJumping = false;
            //Le quito la fuerza de salto remanente
            myRB.velocity = new Vector2(myRB.velocity.x, 0);
            animator.SetBool("isJump", false); //asigno a la variable creada isjump en el animator a false para que deje la animacion de salto 
        }

        if (collision.gameObject.CompareTag("Enemigo")) // si colisionamos con el enemigo
        {
            SceneManager.LoadScene(3); //cargamos la escena 3 que es la de muerte
        }

        if (collision.gameObject.CompareTag("win"))// si colisionamos con el suelo
        {
            SceneManager.LoadScene(2);//cargamos la escena 1 que es la de victoria
        }


    }

    private void OnTriggerEnter2D(Collider2D collision) //controlo las colisones con los trigger en el juego
    {
        

        if(collision.tag == "Points")
        {
            points++; //sumo un valor a la variable puntos
            coin.Play(); //reproduzco el sonido 
            puntos.text = points.ToString(); //actualizo los puntos en la pantalla del jugador
            collision.gameObject.SetActive(false); //desactivo las frutas

        }


    }


}
