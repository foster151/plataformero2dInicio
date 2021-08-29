using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo2 : MonoBehaviour
{
    int rutina;
    float cronometro;
    Animator ani;
    int direccion;
    public float speed_walk;
    public float speed_run;
    GameObject target;
    public bool atacando;
    public GameObject Hit;
    
    public float rango_vision;
    public float rango_visionY;
    public float rango_ataque;
    public GameObject rango;

    public LayerMask LayerM;
    public Vector3 v3;
    public Vector3 v5;
    private bool Ground=true;
    public float Distancia;


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
        if (Physics2D.Raycast(transform.position+v5, transform.right, Distancia,LayerM))
        {
            Ground =! Ground;
        }
        if (Physics2D.Raycast(transform.position + v3,transform.up*-1, Distancia, LayerM))
        {
            
        }
        else
        {
            Ground = !Ground;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position+v5, transform.right * Distancia);
        Gizmos.DrawRay(transform.position + v3, transform.up * -1 * Distancia);
    }
    public void Final_Ani()
    {
        ani.SetBool("attack", false);
        atacando = false;
        rango.GetComponent<RangoEnemigo2>().enabled = true;
    }
    public void Comportamientos()
    {
        if (Vector2.Distance(transform.position, target.transform.position) > rango_vision && !atacando)
        //if (Mathf.Abs(transform.position.x-target.transform.position.x)>rango_vision && !atacando)
        {
            ani.SetBool("run", false);
            cronometro += 1 * Time.deltaTime;
            if (cronometro >= 3)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }
            switch (rutina)
            {
                case 0:
                    ani.SetBool("walk", false);
                    break;
                case 1:
                    direccion = Random.Range(0, 2);
                    rutina++;
                    break;
                case 2:
                    switch (direccion)
                    {
                        case 0:
                            if (Ground)
                            {
                                transform.rotation = Quaternion.Euler(0, 0, 0);
                                transform.Translate(Vector3.right * speed_walk * Time.deltaTime);
                                v3 = new Vector3(0.9f, 0.0f, 0.0f);
                            }
                            else
                            {
                                transform.rotation = Quaternion.Euler(0, 180, 0);
                                transform.Translate(Vector3.right * speed_walk * Time.deltaTime);
                                v3 = new Vector3(-0.9f, 0.0f, 0.0f);
                            }
                            break;
                        case 1:
                            if (Ground)
                            {
                                transform.rotation = Quaternion.Euler(0, 180, 0);
                                transform.Translate(Vector3.right * speed_walk * Time.deltaTime);
                                v3 = new Vector3(-0.9f, 0.0f, 0.0f);
                            }
                            else
                            {
                                transform.rotation = Quaternion.Euler(0, 0, 0);
                                transform.Translate(Vector3.right * speed_walk * Time.deltaTime);
                                v3 = new Vector3(0.9f, 0.0f, 0.0f);
                            }
                            break;
                    }
                    ani.SetBool("walk", true);
                    break;
            }
        }
        else
        {
            if(Vector2.Distance(transform.position,target.transform.position)>rango_ataque && !atacando)
            //if (Mathf.Abs(transform.position.x - target.transform.position.x) > rango_ataque && !atacando)
            {
                if (transform.position.x<target.transform.position.x )
                {
                    ani.SetBool("walk", false);
                    ani.SetBool("run", true);
                    transform.Translate(Vector3.right * speed_run * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    ani.SetBool("attack", false);
                }
                else
                {
                    ani.SetBool("walk", false);
                    ani.SetBool("run", true);
                    transform.Translate(Vector3.right * speed_run * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    ani.SetBool("attack", false);
                }
            }
            else
            {
                if (!atacando)
                {
                    if (transform.position.x<target.transform.position.x)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    else
                    {
                        transform.rotation = Quaternion.Euler(0, 180, 0);
                    }
                    ani.SetBool("walk", false);
                    ani.SetBool("run", false);
                }
            }
        }
    }
}
