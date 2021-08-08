using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Vidas : MonoBehaviour
{
    public Text txtVida;
    public int vida=3;
    Animator dano;
    public GameController controller;
    void Start()
    {
        vida = controller.Vidas();
        txtVida.text= "X " + vida;
        dano = GetComponent<Animator>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "OB" )
        {
            vida -= 1;
            dano.SetBool("dano", true);
            StartCoroutine("TiempoD");
            txtVida.text = "X " + vida;
        }
        if(vida<=0)
        {
            SceneManager.LoadScene("Nivel1");
        }
        if (collision.gameObject.tag == "fin")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    IEnumerator TiempoD()
    {
        yield return new WaitForSeconds(1);
        dano.SetBool("dano", false);
    }
}
