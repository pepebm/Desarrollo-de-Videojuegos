/*
    Ivan Aram Gonzalez Su A01022584
    Jose Manuel Beauregard Mendez A01021716
    Daniel Esteban Tapia A01022285
*/
// Librerias
using UnityEngine;
using System.Collections;

// Clase para controlar la luz direccional
public class DirectionLightFixed : MonoBehaviour {

    void Awake()
    {
        // Modificacion a la intensidad de la luz
        GetComponent<Light>().intensity = 1.26f;
    }
    
	void Start () {}
	void Update () {}
}
