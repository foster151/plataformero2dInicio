using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangoEnemigo2 : MonoBehaviour
{
    public Animator ani;
    public Enemigo2 enemigo;
    public PersonajeMovimiento Player;

    public LayerMask LayerM;
    public float Distancia;

    public CamaraScript CameraShake;
    public GameObject Rango;
    public static int vida=11;
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag=="Player")
        {
            Player.EnemiJump();
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Physics2D.Raycast(transform.position, transform.right, Distancia, LayerM))
        {
            //vida = vida - 1;
            //Debug.Log("Total: " + vida);
            ani.SetBool("walk", false);
            ani.SetBool("run", false);
            ani.SetBool("attack", true);
            enemigo.atacando = true;
            Player.EnemyKnokBack(transform.position.x);
            //SendMessage("EnemyKnokBack", transform.position.x);
            CameraShake.duration = 0.1f;
            CameraShake.magnitud = 0.3f;
            StartCoroutine(CameraShake.Shake());
            Rango.GetComponent<RangoEnemigo2>().enabled = false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.right * Distancia);
    }
}
