using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivation : MonoBehaviour
{
    public PersonajeMovimiento Player;
    public GameObject bosGO;
    private void Start()
    {
        bosGO.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Player.animacion();
            Player.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            Player.enabled = false;
            BOSSUI.instance.BossActivator();
            StartCoroutine(WaitForboss());
        }
    }
    IEnumerator WaitForboss()
    {
        bosGO.SetActive(true);
        yield return new WaitForSeconds(2f);
        Player.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        Player.enabled = true;
        Destroy(gameObject);
    }
}
