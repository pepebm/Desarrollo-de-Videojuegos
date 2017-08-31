/*
    Ivan Aram Gonzalez Su A01022584
    Jose Manuel Beauregard Mendez A01021716
    Daniel Esteban Tapia A01022285
*/
// Librerías para Unity
using UnityEngine;
using System.Collections;

// Esta clase es para controlar el movimiento de los asteroides que se mueven diagonalmente
public class MovAsteroidD : MonoBehaviour {
    // La variable _dis guarda la distancia recorrida por cada asteroide
    private float _dis;
    // La variable _model guarda que modelo es el asteroide y es publica para accesar más fácil a ella
    public int _model;
    // La variable _initPos guarda un vector de 2D con la posicion inicial de cada asteroide
    private Vector2 _initPos;

    // Use this for initialization
    void Start()
    {
        // Aqui se inicializa la variable _initPos y _dis
        _initPos = transform.localPosition;
        _dis = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Aqui se obtiene la distancia recorrida por el asteroide
        _dis += Mathf.Sqrt(Mathf.Pow(0.21f, 2) + Mathf.Pow(0.08f, 2));

        // Aqui se traslada el asteroide, la variable _model hace que cada asteroide tenga diferentes direcciones
        if (_model == 0) GetComponent<Transform>().Translate(new Vector2(0.21f, -0.08f));
        else GetComponent<Transform>().Translate(new Vector2(0.21f, 0.08f));

        // Aqui se checa que no haya pasado 30 unidades, si ya pasó las 30 unidades el asteroide
        // regresa a su posicion inicial
        if (_dis >= 30)
        {
            transform.localPosition = _initPos;
            _dis = 0;
        }
    }
}
