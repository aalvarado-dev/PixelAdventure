using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    Rigidbody2D myRB;
    private Animator animator; //Para campturar el componente Animator del Jugador

    public float maxSpeed;
    SpriteRenderer myrenderer;
    bool facingRight = true;
    bool isJumping = false; //Para comprobar si ya está saltando
    [Range(1, 500)] public float potenciaSalto; //variable que controla la potencia de salto del jugador

    private void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myrenderer = GetComponent<SpriteRenderer>();

        //Capturo y asocio el componente Animator del Jugador
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        //Si pulso la tecla de salto (espacio) y no estaba saltando
        if (Input.GetButton("Jump") && !isJumping)
        {
            //Le aplico la fuerza de salto multiplicado por la potencia de salto
            myRB.AddForce(Vector2.up * potenciaSalto);
            //Digo que esta saltando para que no pueda volver a saltar   
            isJumping = true;
            animator.SetBool("isJump", true);
        }
    }

    private void Update()
    {
        float move = Input.GetAxis("Horizontal");

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }
        myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);
        animator.SetFloat("MoveSpeed", Mathf.Abs(move));
    }
    void Flip()
    {
        facingRight = !facingRight;
        myrenderer.flipX = !myrenderer.flipX;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            //Digo que no esta saltando para que pueda volver a saltar
            isJumping = false;
            //Le quito la fuerza de salto remanente que tuviera
            myRB.velocity = new Vector2(myRB.velocity.x, 0);
            animator.SetBool("isJump", false);
        }
    }
}
