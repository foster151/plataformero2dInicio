using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float Velocidad = 0, linDerecha = 0, linIzquierda = 0;
    SpriteRenderer Flip;
    Quaternion rotar;
    Vector2 DER = Vector2.right;
    void Start()
    {
        //Flip = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(DER * Time.deltaTime * Velocidad);
        if(transform.position.x>=linDerecha)
        {
            //Flip.flipX = false;
            rotar.y = 180;
            transform.rotation = rotar;
        }
        if(transform.position.x<=linIzquierda)
        {
            //Flip.flipX = true;
            rotar.y = 0;
            transform.rotation = rotar;
        }
    }
}
