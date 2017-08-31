/*
    Ivan Aram Gonzalez Su A01022584
    Jose Manuel Beauregard Mendez A01021716
    Daniel Esteban Tapia A01022285
*/
// Librerías para Unity
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Balas : MonoBehaviour {
    //variable inicial de la bala
    public Vector3 _initialPos;
    //nos sirve para usar un metodo de la clase disparar
    private Disparar _control;
    // guardara los puntos del jugador
    private static int _pts;
    //servira para darle _control a la bala
    public bool _onShot;
    //texto en el cual se despliegara el puntaje
    public Text score;

	void Start () {
        _pts = 0;
        _initialPos = transform.localPosition;
        _control = FindObjectOfType<Disparar>();
        _onShot = false;
	}
    //agrega los puntos al score
    private static void addPts(int p) { _pts += p; }
    //regresa los puntos actuales del jugador
    public static int getPts() { return _pts; }

    void Update()
    {
        //si _onShot es true la bala se traslada verticalmente, se cambia cuando la bala colisiona con la barra superior
        if (_onShot) GetComponent<Transform>().Translate(new Vector2(0f, 0.3f)); 
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name != "spaceship")
        {
            //despues de hacer colision con algo que no sea la nave del jugador, la bala es regresada a la posicion inicial
            _onShot = false;
            transform.position = _initialPos;
            _control.addBullet();
            //si la bala colisiona con algun invader, se agrega puntos al score del jugador
            if (col.gameObject.tag == "Invader")
            {
                if (col.gameObject.GetComponent<Invader>())
                {
                    if (col.gameObject.GetComponent<Invader>()._dispara) addPts(100);
                    else addPts(50);
                    score.text = "Score: " + _pts;
                }
                //elimina al invader
                Destroy(col.gameObject);
            }
        }
    }
}
