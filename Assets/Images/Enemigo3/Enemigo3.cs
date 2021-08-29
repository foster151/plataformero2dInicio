using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Enemigo3Cambio
{
    Paredes,Plataformas
}

public class Enemigo3 : MonoBehaviour
{
    public float maxSpeed = 1f;
    public float Speed = 5f;
    private Rigidbody2D rb2d;
    SpriteRenderer Flip;

    private bool Ground=true;
    public Vector3 v3;
    public float Distancia;
    public LayerMask LayerM;

    public Enemigo3Cambio Cambio;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Flip = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position + v3, transform.up * -1 * Distancia);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        switch(Cambio)
        {
            case Enemigo3Cambio.Paredes:
                rb2d.AddForce(Vector2.right * Speed);
                float limitSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
                rb2d.velocity = new Vector2(limitSpeed, rb2d.velocity.y);
                if (rb2d.velocity.x > -0.1f && rb2d.velocity.x < 0.1f)
                {
                    Speed = -Speed;
                    rb2d.velocity = new Vector2(Speed, rb2d.velocity.y);
                }
                if (Speed < 0) Flip.flipX = true;
                else if (Speed > 0) Flip.flipX = false;

                break;
            case Enemigo3Cambio.Plataformas:
                if (Ground)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    transform.Translate(Vector3.right * Speed * Time.deltaTime);
                    v3 = new Vector3(0.6f, 0.0f, 0.0f);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    transform.Translate(Vector3.right * Speed * Time.deltaTime);
                    v3 = new Vector3(-0.6f, 0.0f, 0.0f);
                }
                if (Physics2D.Raycast(transform.position, transform.right, Distancia, LayerM))
                {
                    Ground = !Ground;
                }
                if (Physics2D.Raycast(transform.position + v3, transform.up * -1, Distancia, LayerM))
                {
                    
                }
                else
                {
                    Ground = !Ground;
                }
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag=="Player")
        {
            float YOject = 1.7f;
            if(transform.position.y+YOject< col.transform.position.y)
            {
                col.SendMessage("EnemiJump");
                Destroy(gameObject);
            }
            else
            {
                col.SendMessage("EnemyKnokBack",transform.position.x);
            }
        }
    }
}
