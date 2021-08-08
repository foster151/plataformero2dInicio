using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovimientoPersonaje : MonoBehaviour
{
    public Text busca;
    public float velocidad = 3.0f,fuerzaSalto=5;
    Animator Megaman;
    SpriteRenderer Flip;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Busca");
        Megaman = GetComponent<Animator>();
        Flip = GetComponent<SpriteRenderer>();
    }
    IEnumerator Busca()
    {
        yield return new WaitForSeconds(3);
        busca.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d"))
        {
            Flip.flipX = false;
            Megaman.SetBool("correr", true);
            transform.Translate(Vector2.right * Time.deltaTime * velocidad);
        }
        if (Input.GetKeyUp("d"))
        {
            Megaman.SetBool("correr", false);
        }
        if (Input.GetKey("a"))
        {
            Flip.flipX = true;
            Megaman.SetBool("correr", true);
            transform.Translate(Vector2.left * Time.deltaTime * velocidad);
        }
        if (Input.GetKeyUp("a"))
        {
            Megaman.SetBool("correr", false);
        }
        if (Input.GetKeyDown("space")&& Mathf.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.y)<0.01f)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            Megaman.SetBool("jump", true);
            Megaman.SetBool("Idle", true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            Megaman.SetBool("Idle", false);
            Megaman.SetBool("jump", false);
        }
    }
    public bool Arma = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="arma")
        {
            Arma = true;
            Destroy(other.gameObject);
        }
    }
}
