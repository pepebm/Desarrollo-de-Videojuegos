/*
    Ivan Aram Gonzalez Su A01022584
    Jose Manuel Beauregard Mendez A01021716
    Daniel Esteban Tapia A01022285
*/
//Librerias
using UnityEngine;
using System.Collections;

// Clase para manipular el audio
public class soundController : MonoBehaviour {
    //Variable tipo gameController
    private gameController gc;

	void Start () {
        //Inicializar la variable tipo gameController
        gc = FindObjectOfType<gameController>();
	}
	
    //Funcion para subir el volumen
    public void volUp()
    {
        if (gc) gc.volumen(0.1f);
    }

    //Funcion para bajar el volumen
    public void volDown()
    {
        if (gc) gc.volumen(-0.1f);
    }

    //Funcion para pausar/poner la musica
    public void pausePlay()
    {
        if (gc) gc.pauseMusic();
    }
    
	void Update () {}
}
