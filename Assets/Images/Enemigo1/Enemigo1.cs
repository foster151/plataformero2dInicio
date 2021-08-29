using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo1 : MonoBehaviour
{
    Animator ani;
    public float speed_run;
    GameObject target;
    public bool atacando;
    public float rango_vision;
    public float rango_ataque;
    public GameObject rango;
    public GameObject Hit;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Comportamientos();
    }
    public void Final_Ani()
    {
        ani.SetBool("boom", false);
        atacando = false;
        rango.GetComponent<BoxCollider2D>().enabled = true;
    }
    public void ColliderWeaponTrue()
    {
        Hit.GetComponent<BoxCollider2D>().enabled = true;
    }
    public void ColliderWeaponFalse()
    {
        Hit.GetComponent<BoxCollider2D>().enabled = false;
    }
    public void Comportamientos()
    {
        if (Vector2.Distance(transform.position, target.transform.position) > rango_vision && !atacando)
        {
            ani.SetBool("run", false);
            ani.SetBool("idle", false);
        }
        else
        {
            if (Vector2.Distance(transform.position, target.transform.position) > rango_ataque && !atacando)
            {
                ani.SetBool("idle", true);
                if (transform.position.x < target.transform.position.x)
                {
                   Invoke("InicioAni", 0.3f);
                   ani.SetBool("boom", false);
                }
                else
                {
                   Invoke("InicioAni2", 0.3f);
                   ani.SetBool("boom", false);
                }
                
            }
            else
            {
                if (!atacando)
                {
                    if (transform.position.x < target.transform.position.x)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    else
                    {
                        transform.rotation = Quaternion.Euler(0, 180, 0);
                    }
                    ani.SetBool("idle", false);
                    ani.SetBool("run", false);
                }
            }
        }
    }
    void InicioAni()
    {
        ani.SetBool("idle", false);
        ani.SetBool("run", true);
        transform.Translate(Vector3.right * speed_run * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    void InicioAni2()
    {
        ani.SetBool("idle", false);
        ani.SetBool("run", true);
        transform.Translate(Vector3.right * speed_run * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, 180, 0);
    }
}
