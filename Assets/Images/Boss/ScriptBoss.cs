using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptBoss : MonoBehaviour
{
    public float maxHealth = 10f;
    public float currentHealth;
    private SpriteRenderer spr;
    public Image VidaImg;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        DamageBoss();
    }
    public void DamageBoss()
    {
        //float deep = currentHealth / maxHealth;
        VidaImg.fillAmount = currentHealth / maxHealth;
        //Debug.Log("deep " + deep);
    }

    public void TakeDamage(int damge)
    {
        currentHealth -= damge;
        Debug.Log("fill " + VidaImg.fillAmount);
        EnemyColor();
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            this.enabled = false;
        }
        Debug.Log("Vida del boss" + currentHealth);
    }
    public void EnemyColor()
    {
        Color color = new Color(255 / 255f, 80 / 255f, 80 / 255f);
        spr.color = color;
        Invoke("ActivaColor", 0.3f);
    }
    void ActivaColor()
    {
        spr.color = Color.white;
    }
    private void OnDestroy()
    {
        BOSSUI.instance.BossDesactivador();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.SendMessage("EnemyKnokBack", transform.position.x);
        }
    }
}
