using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeMovimiento : MonoBehaviour
{
    public static PersonajeMovimiento instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public float JumpForce=5f, speed,maxSpeed;
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Ground;
    private bool movement = true;
    private bool Jump;
    private SpriteRenderer spr;
    // Attaque
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public LayerMask BossLayers;
    public int AttackDamage = 1;
    public float attackRatte = 2f;
    float nextAttackTime = 0f;
    //llaves
    private int ContKey = 0;
    public GameObject PuertaSalaBos;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time>=nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Attack();
                AttackBoss();
                nextAttackTime = Time.time + 1f / attackRatte;
            }
        }

        Horizontal = Input.GetAxisRaw("Horizontal");
        if (!movement) Horizontal = 0;
        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        //if(Horizontal<0.0f) Flip.flipX = true;
        //else if(Horizontal > 0.0f) Flip.flipX = false;


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
        if(Input.GetKeyDown(KeyCode.Space)&&Ground)
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

        Rigidbody2D.AddForce(Vector2.right * speed * Horizontal);
        float limitSpeed = Mathf.Clamp(Rigidbody2D.velocity.x, -maxSpeed, maxSpeed);
        Rigidbody2D.velocity = new Vector2(limitSpeed, Rigidbody2D.velocity.y);

        if(Ground)
        {
            Rigidbody2D.velocity = fixedVelocity;
        }

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
    public void animacion()
    {
        Animator.SetBool("Runing", false);
    }

    public void EnemyKnokBack(float enemyPosX)
    {
        Jump = true;
        float side = Mathf.Sign(enemyPosX - transform.position.x);
        Rigidbody2D.AddForce(Vector2.left* side * JumpForce, ForceMode2D.Impulse) ;

        movement = false;
        Color color = new Color(255/255f, 80/255f, 80/255f);
        spr.color = color;
        Invoke("ActivaMovimiento", 0.5f);
    }
    void ActivaMovimiento()
    {
        movement = true;
        spr.color = Color.white;
    }
    void Attack()
    {
        //Animacion de Attaque
        Animator.SetTrigger("attack");
        //Detectamos Enemigo
        Collider2D[] hitEnemies= Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<DanoEnemigo>().TakeDamage(AttackDamage);
        }
    }
    void AttackBoss()
    {
        Animator.SetTrigger("attack");

        Collider2D[] hitBoss = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, BossLayers);
        foreach (Collider2D enemy in hitBoss)
        {
            enemy.GetComponent<ScriptBoss>().TakeDamage(AttackDamage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "llave")
        {
            ContKey += 1;
            Debug.Log(ContKey);
            if (ContKey == 2)
            {
                Destroy(PuertaSalaBos);
                Debug.Log("sala del jefe activa");
            }
        }
    }
}
