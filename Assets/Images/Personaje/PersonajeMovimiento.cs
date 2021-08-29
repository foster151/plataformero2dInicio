using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeMovimiento : MonoBehaviour
{
    public float JumpForce=5f, speed,maxSpeed;
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Ground;
    SpriteRenderer Flip;
    private bool movement = true;
    private bool Jump;
    private SpriteRenderer spr;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        Flip = GetComponent<SpriteRenderer>();
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        if (!movement) Horizontal = 0;
        if(Horizontal<0.0f) Flip.flipX = true;
        else if(Horizontal > 0.0f) Flip.flipX = false;


        Animator.SetBool("Runing", Horizontal != 0.0f);

        Debug.DrawRay(transform.position, Vector3.down * 1.7f, Color.blue);
        if (Physics2D.Raycast(transform.position, Vector3.down, 1.7f))
        {
            Ground = true;
            Animator.SetBool("jump2", false);
            Animator.SetBool("jump", false);
        }
        else
        {
            Animator.SetBool("jump2",true);
            Animator.SetBool("jump", true);
            Ground = false;
        }
        if(Input.GetKeyDown(KeyCode.W)&&Ground)
        {
            jump();
        }
    }
    private void jump()
    {
        Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, 0);
        Rigidbody2D.AddForce(Vector2.up*JumpForce, ForceMode2D.Impulse);
    }


    private void FixedUpdate()
    {
        Vector3 fixedVelocity = Rigidbody2D.velocity;
        fixedVelocity.x *= 0.75f;
        if(Ground)
        {
            Rigidbody2D.velocity = fixedVelocity;
        }

        Rigidbody2D.AddForce(Vector2.right * speed * Horizontal);
        float limitSpeed = Mathf.Clamp(Rigidbody2D.velocity.x, -maxSpeed, maxSpeed);
        Rigidbody2D.velocity = new Vector2(limitSpeed, Rigidbody2D.velocity.y);
        //Rigidbody2D.velocity = new Vector2(Horizontal*speed, Rigidbody2D.velocity.y);

        if (Jump)
        {
            Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, 0);
            Rigidbody2D.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            Jump = false;
        }
    }
    public void EnemiJump()
    {
        Jump = true;
    }
    public void EnemyKnokBack(float enemyPosX)
    {
        Jump = true;
        float side = Mathf.Sign(enemyPosX - transform.position.x);
        Rigidbody2D.AddForce(Vector2.left* side * JumpForce, ForceMode2D.Impulse) ;

        movement = false;
        Invoke("ActivaMovimiento", 0.5f);
        Color color = new Color(255/255f, 80/255f, 80/255f);
        spr.color = color;
    }
    void ActivaMovimiento()
    {
        movement = true;
        spr.color = Color.white;
    }
}
