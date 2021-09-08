using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Llave : MonoBehaviour
{
    public Text textLlave;
    public float LimArriba = 0, LimInferior = 0, Velocidad = 0;
    Vector2 dirY = Vector2.up;
    public GameObject PuertaNvl2;

    //player
    public PersonajeMovimiento Player;
    void Update()
    {
        transform.Translate(dirY * Time.deltaTime * Velocidad);
        if (transform.position.y >= LimArriba)
        {
            dirY = Vector2.down;
        }
        if (transform.position.y <= LimInferior)
        {
            dirY = Vector2.up;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player.animacion();
            Player.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            Player.enabled = false;
            textLlave.text = "Felicidades encontraste la primer llave \nDesbloqueaste el nivel 2 ";
            Invoke("PlayerMovimiento", 4.0f);
            Destroy(PuertaNvl2);
        }
    }
    void PlayerMovimiento()
    {
        Player.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        Player.enabled = true;
        textLlave.text = " ";
        Destroy(gameObject);
    }
}
