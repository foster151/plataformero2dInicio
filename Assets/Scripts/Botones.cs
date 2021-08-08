using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour
{
    TextReader LeerArchivo;
    int nivel,coins,vidas;
    public GameController controller;
    public void IniciarPartida()
    {
        LeerArchivo = new StreamReader(@"C:\Users\" + Environment.UserName + @"\Documents\Megaman\Save\save.txt");
        nivel = int.Parse(LeerArchivo.ReadLine());

        LeerArchivo.Close();
        if(nivel!=1)
        {
            SceneManager.LoadScene("MenuContinuar");
        }
        else
        {
            SceneManager.LoadScene("Nivel1");
        }
    }
    public void BottonContinuar()
    {
        LeerArchivo = new StreamReader(@"C:\Users\" + Environment.UserName + @"\Documents\Megaman\Save\save.txt");
        nivel = int.Parse(LeerArchivo.ReadLine());
        coins = int.Parse(LeerArchivo.ReadLine());
        vidas = int.Parse(LeerArchivo.ReadLine());
        controller.DatosNivel(nivel,coins, vidas); 
        SceneManager.LoadScene(nivel);
    }
}
