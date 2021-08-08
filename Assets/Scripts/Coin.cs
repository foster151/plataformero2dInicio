using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public Text txtcoin;
    public int coin = 0;
    public GameController controller;
    void Start()
    {
        coin = controller.Coins();
        txtcoin.text = "= " + coin;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coins")
        {
            coin += 1;
            txtcoin.text = "= " + coin;
            Destroy(collision.gameObject);
        }
    }
}
