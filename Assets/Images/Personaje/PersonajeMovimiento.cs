using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeMovimiento : MonoBehaviour
{
    public float JumpForce, speed;
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Ground;
    SpriteRenderer Flip;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        Flip = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
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
        Rigidbody2D.AddForce(Vector2.up*JumpForce);
    }
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal*speed, Rigidbody2D.velocity.y);
    }
}
