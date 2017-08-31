/*
    Ivan Aram Gonzalez Su A01022584
    Jose Manuel Beauregard Mendez A01021716
    Daniel Esteban Tapia A01022285
*/
// Librerías para Unity
using UnityEngine;
using UnityEngine.UI; // Librería para usar el tipo de dato Text
using System.Collections;

// Esta clase es para controlar el movimiento de la segunda nave (ship2)
public class MovementShip2 : MonoBehaviour {
    // La variable _choques es para mostrar en pantalla el número de choques que lleva esta nave
    public Text _choques;
    // La variable _endGameMsj es para mostrar un mensaje al final del juego diciendo quien ganó
    public Text _endGameMsj;
    // La variable _numChoques guarda el numero de choques que ha tenida esta nave
    private int _numChoques;

    // Use this for initialization
    void Start() {
        // Se inicializa _numChoques
        _numChoques = 0;
    }

    // Esta función es para detectar colisiones de la nave
    void OnCollisionEnter2D(Collision2D col)
    {
        // Aqui se lista todos los objetos con los cuales se va a detectar la colision
        if (col.gameObject.name == "ship" || col.gameObject.name == "sr_v1" || col.gameObject.name == "sr_v2" || col.gameObject.name == "sr_v3"
            || col.gameObject.name == "sr_v4" || col.gameObject.name == "sr_v5" || col.gameObject.name == "sr_v6" || col.gameObject.name == "sr_v7"
            || col.gameObject.name == "sr_v8" || col.gameObject.name == "sr_v9" || col.gameObject.name == "sr_v10" || col.gameObject.name == "sr_v11"
            || col.gameObject.name == "sr_h1" || col.gameObject.name == "sr_h2" || col.gameObject.name == "sr_h3" || col.gameObject.name == "sr_h4"
            || col.gameObject.name == "sr_h5" || col.gameObject.name == "sr_h6" || col.gameObject.name == "sr_h7" || col.gameObject.name == "sr_h8"
            || col.gameObject.name == "sr_d1" || col.gameObject.name == "sr_d2" || col.gameObject.name == "sr_v12")
        {
            // El texto de _choques mostrado en pantalla cambia dependiendo de la variable _numChoques
            _choques.text = "Player 2: " + (100 - (++_numChoques) * 5).ToString() + "%  (" + _numChoques + " hits)";
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Aqui se checa que tecla esta presionando el usuario
        // Si es la flecha hacia arriba la nave se traslada hacia adelante con un vector de 2D
        if (Input.GetKey(KeyCode.UpArrow))
            GetComponent<Transform>().Translate(new Vector2(0f, 0.25f));

        // Si es la flecha hacia abajo la nave se traslada hacia adelante con un vector de 2D
        if (Input.GetKey(KeyCode.DownArrow))
            GetComponent<Transform>().Translate(new Vector2(0f, -0.25f));

        // Si es la flecha hacia la derecha la nave se traslada hacia adelante con un vector de 2D
        if (Input.GetKey(KeyCode.RightArrow))
            GetComponent<Transform>().Translate(new Vector2(0.25f, 0f));

        // Si es la flecha hacia  la izquierda la nave se traslada hacia adelante con un vector de 2D
        if (Input.GetKey(KeyCode.LeftArrow))
            GetComponent<Transform>().Translate(new Vector2(-0.25f, 0f));

        // Si es el guión la nave rotará en el eje Z en contra de las manecillas del reloj
        if (Input.GetKey(KeyCode.Minus))
            transform.Rotate(new Vector3(0f, 0f, 8.0f));

        // Si es el Shift izquierdo la nave rotará en el eje Z a favor de las manecillas del reloj
        if (Input.GetKey(KeyCode.RightShift))
            transform.Rotate(new Vector3(0f, 0f, -8.0f));

        // Aqui se checa si el numero de choques es mayor o igual a 20 y también se checa que nadie haya ganado todavía
        // Si se cumple lo anterior se mostrara un mensaje de que la nave 1 ganó
        if (_numChoques >= 20 && _endGameMsj.text == "") _endGameMsj.text = "Player 1 wins!";
    }
}
