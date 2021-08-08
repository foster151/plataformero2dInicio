using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class botonsalirReiniciar : MonoBehaviour
{
    public GameObject MenuPausa;
    TextWriter archivo;
    TextReader LeerArchivo;
    int nivel, coins, vidas;
    public GameController controller;
    public void Pausa()
    {
        MenuPausa.SetActive(true);
    }
    public void Continuar()
    {
        MenuPausa.SetActive(false);
    }
    public void Reiniciar()
    {
        archivo = new StreamWriter(@"C:\Users\" + Environment.UserName + @"\Documents\Megaman\Save\save.txt");
        archivo.WriteLine(1);//nivel
        archivo.WriteLine(0);//vidas
        archivo.WriteLine(3);//monedas
        archivo.Close();
        LeerArchivo = new StreamReader(@"C:\Users\" + Environment.UserName + @"\Documents\Megaman\Save\save.txt");
        nivel = int.Parse(LeerArchivo.ReadLine());
        coins = int.Parse(LeerArchivo.ReadLine());
        vidas = int.Parse(LeerArchivo.ReadLine());
        controller.DatosNivel(nivel, coins, vidas);
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
