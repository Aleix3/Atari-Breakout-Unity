using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed = 5f; // Velocidad del movimiento

    bool automatic = false;

    bool way = false;

    Ball ball;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        ball = FindObjectOfType<Ball>();
    }

    void Update()
    {
        Vector2 velocity = rb.velocity;

        if(Input.GetKeyDown(KeyCode.M))
        {
            automatic = !automatic;
        }

        if(automatic)
        {
            Rigidbody2D ballRb = ball.GetComponentInParent<Rigidbody2D>();

            // Mant�n la posici�n actual en Y y solo iguala la X
            if(way)
            {
                rb.position = new Vector2(ballRb.position.x + 0.1f, rb.position.y);
            }
            else
            {
                rb.position = new Vector2(ballRb.position.x - 0.1f, rb.position.y);
            }
            
            
        }
        else
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                velocity.x = moveSpeed; // Mover a la derecha
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                velocity.x = -moveSpeed; // Mover a la izquierda
            }
            else
            {
                velocity.x = 0; // Detener el movimiento horizontal si no se presiona ninguna tecla
            }

            rb.velocity = velocity;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            way = !way;
        }


    }
}
