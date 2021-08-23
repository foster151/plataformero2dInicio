using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangoEnemigo1 : MonoBehaviour
{
    public Animator ani;
    public Enemigo1 enemigo;
    public GameObject BoomEN;
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            Debug.Log("playerdetectado");
            ani.SetBool("idle", false);
            ani.SetBool("run", false);
            ani.SetBool("boom", true);
            enemigo.atacando = true;
            GetComponent<BoxCollider2D>().enabled = false;
            Invoke("Kboom", 0.4f);
        }
    }
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

    }
}
