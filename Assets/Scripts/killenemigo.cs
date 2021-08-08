using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killenemigo : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
