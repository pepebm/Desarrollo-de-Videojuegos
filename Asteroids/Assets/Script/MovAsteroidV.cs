/*
    Ivan Aram Gonzalez Su A01022584
    Jose Manuel Beauregard Mendez A01021716
    Daniel Esteban Tapia A01022285
*/
// Librerías para Unity
using UnityEngine;
using System.Collections;

// Esta clase es para controlar el movimiento de los asteroides que se mueven verticalmente
public class MovAsteroidV : MonoBehaviour {
    // La variable _dis guarda la distancia recorrida por cada asteroide
    // Y la variable _vel controla la velocidad de cada asteroide
    private float _dis, _vel;
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
        // Aqui dependiendo de _model se asigna una velocidad diferente
        if (_model == 0) _vel = 0.1f;
        else if (_model == 1) _vel = 0.05f;
        else if (_model == 2) _vel = 0.15f;
        else if (_model == 3) _vel = -0.1f;
        else if (_model == 4) _vel = -0.05f;
        else if (_model == 5) _vel = -0.15f;
    }

    // Update is called once per frame
    void Update() {
        // La estructura de control if es para checar la direccion del asteroide (arriba o abajo)
        // Dentro se suma lo que el asteroide va avanzando y se traslada al asteroide con un vector
        // de 2D
        if (_vel > 0)
        {
            _dis += _vel;
            GetComponent<Transform>().Translate(new Vector2(0f, -_vel));
        }
        else
        {
            _dis -= _vel;
            GetComponent<Transform>().Translate(new Vector2(0f, -_vel));
        }

        // Aqui se checa que no haya pasado 12 unidades, si ya pasó las 12 unidades el asteroide
        // regresa a su posicion inicial
        if (_dis >= 12)
        {
            transform.localPosition = _initPos;
            _dis = 0;
        }
    }
}
