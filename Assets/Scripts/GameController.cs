using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    static int CantidadCoins = 0,CantidadVidas=3,nivelDejuego=1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DatosNivel(int nivel,int coin,int vida)
    {
        nivelDejuego = nivel;
        CantidadCoins = coin;
        CantidadVidas = vida;
    }
    public int Nivel()
    {
        return nivelDejuego;
    }
    public int Coins()
    {
        return CantidadCoins;    
    }
    public int Vidas()
    {
        return CantidadVidas;
    }
}
