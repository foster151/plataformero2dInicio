using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class CrearArchivo : MonoBehaviour
{
    TextWriter archivo;
    string directorio;
    void Start()
    {
        directorio = @"C:\Users\" + Environment.UserName + @"\Documents\Megaman\Save";
        if (Directory.Exists(directorio)==false)
        {
            DirectoryInfo di = Directory.CreateDirectory(directorio);
            archivo =new StreamWriter( @"C:\Users\" + Environment.UserName + @"\Documents\Megaman\Save\save.txt");
            archivo.WriteLine(1);//nivel
            archivo.WriteLine(0);//vidas
            archivo.WriteLine(3);//monedas
            archivo.Close();
        }
    }
}
