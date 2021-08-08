using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public MovimientoPersonaje arma;
    public Vidas Vidas;
    public Coin Coin;
    TextWriter Archivo;
    TextReader LeerArchivo;
    int nivel;
    public GameController Controller;
    void Start()
    {
        LeerArchivo= new StreamReader(@"C:\Users\" + Environment.UserName + @"\Documents\Megaman\Save\save.txt");
        nivel= int.Parse(LeerArchivo.ReadLine());
        nivel += 1;
        LeerArchivo.Close();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (arma.Arma)
            {
                Archivo = new StreamWriter(@"C:\Users\" + Environment.UserName + @"\Documents\Megaman\Save\save.txt");
                Archivo.WriteLine(nivel);
                Archivo.WriteLine(Coin.coin);
                Archivo.WriteLine(Vidas.vida);
                Archivo.Close();
                Controller.DatosNivel(nivel, Coin.coin, Vidas.vida);
                SceneManager.LoadScene("Nivel2");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
