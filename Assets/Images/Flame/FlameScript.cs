using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameScript : MonoBehaviour
{
    float moveSpeed;
    Rigidbody2D rb2d;
    Vector2 moveDirection;
    PersonajeMovimiento target;
    void Start()
    {
        moveSpeed = GetComponent<VariableFlame>().Speed;
        rb2d = GetComponent<Rigidbody2D>();
        target = PersonajeMovimiento.instance;

        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb2d.velocity = new Vector2(moveDirection.x, moveDirection.y);

        StartCoroutine(destruir());
    }
    IEnumerator destruir()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            collision.SendMessage("EnemyKnokBack", transform.position.x);
        }
    }
}
