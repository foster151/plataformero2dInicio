using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoEnemigo : MonoBehaviour
{
    public int maxHealth = 2;
    int currentHealth;

    private Rigidbody2D Rigidbody2D;
    private bool Jump;
    public float JumpForce = 6f;
    private SpriteRenderer spr;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        Rigidbody2D = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(int damge)
    {
        currentHealth -= damge;
        EnemyKnokBack();
        if (currentHealth <= 0)
        {
            Die();
            Destroy(gameObject);
            this.enabled = false;
        }
    }
    public void EnemyKnokBack()
    {
        Jump = true;
        Color color = new Color(255 / 255f, 80 / 255f, 80 / 255f);
        spr.color = color;
        Invoke("ActivaColor", 0.3f);
    }
    void ActivaColor()
    {
        spr.color = Color.white;
    }
    void Die()
    {
        Debug.Log("Enemigo Muerto");
        //die animation
    }
    private void FixedUpdate()
    {
        if (Jump)
        {
            Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, 0);
            Rigidbody2D.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            Jump = false;
        }
    }
}
