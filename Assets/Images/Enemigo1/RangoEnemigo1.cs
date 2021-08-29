using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangoEnemigo1 : MonoBehaviour
{
    public Animator ani;
    public Enemigo1 enemigo;
    public GameObject BoomEN;

    public LayerMask LayerM, LayerM2;
    public float Distancia;
    void Kboom()
    {
        Destroy(BoomEN);
    }
    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (Physics2D.Raycast(transform.position, transform.right, Distancia, LayerM))
        {
            //ani.SetBool("idle", false);
            //ani.SetBool("run", false);
            ani.SetBool("boom", true);
            enemigo.atacando = true;
            //GetComponent<BoxCollider2D>().enabled = false;
            Invoke("Kboom", 0.4f);
        }
        if (Physics2D.Raycast(transform.position, transform.right, Distancia, LayerM2))
        {
            ani.SetBool("boom", true);
            enemigo.atacando = true;
            //GetComponent<BoxCollider2D>().enabled = false;
            Invoke("Kboom", 0.4f);
        }
        if (Physics2D.Raycast(transform.position, transform.up, Distancia, LayerM))
        {
            ani.SetBool("boom", true);
            enemigo.atacando = true;
            //GetComponent<BoxCollider2D>().enabled = false;
            Invoke("Kboom", 0.4f);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.right * Distancia);
        Gizmos.DrawRay(transform.position, transform.up * Distancia);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            float YOject = 1.9f;
            if (transform.position.y + YOject < col.transform.position.y)
            {
                col.SendMessage("EnemyKnokBack", transform.position.x);
            }
            else
            {
                col.SendMessage("EnemyKnokBack", transform.position.x);
            }
        }
    }
}
