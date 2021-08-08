using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataformas : MonoBehaviour
{
    public float LimArriba = 0,LimInferior=0,Velocidad=0;
    Vector2 dirY = Vector2.up;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dirY * Time.deltaTime * Velocidad);
        if(transform.position.y>=LimArriba)
        {
            dirY = Vector2.down;
        }
        if (transform.position.y<=LimInferior)
        {
            dirY = Vector2.up;
        }
    }
}
