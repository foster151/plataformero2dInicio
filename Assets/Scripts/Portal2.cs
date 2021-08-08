using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Portal2 : MonoBehaviour
{
    public GameObject menugameover;
    public Text findejuego;
    Animator Fin;
    // Start is called before the first frame update
    void Start()
    {
        Fin = GetComponent<Animator>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "portal")
        {
            Fin.SetBool("fin", true);
            findejuego.text = " ";
            findejuego.text = "Gracias por jugar";
            StartCoroutine("Gameover");
        }
    }
    IEnumerator Gameover()
    {
        yield return new WaitForSeconds(3);
        menugameover.SetActive(true);
    }
}
