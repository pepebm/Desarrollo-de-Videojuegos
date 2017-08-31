/*
    Ivan Aram Gonzalez Su A01022584
    Jose Manuel Beauregard Mendez A01021716
    Daniel Esteban Tapia A01022285
*/
// Librerías para Unity
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Leap;
using Leap.Unity;

public class Disparar : MonoBehaviour {
    //array que contendra las _balas del jugador
    public GameObject[] _bala;
    //guardara la cantidad de _bullets disparadas
    private int _bullets;
    //si es true, el jugador perdio
    public static bool _lose;
    //si pierde, esta variable mostrara el titulo de fin dejuego
    public Text _endGameMsj;
    //controldaor de leap
    Leap.Controller _leap;

    void Start () {
        _lose = false;
        _bullets = 3;
        _leap = new Controller();
    }
	
    public void addBullet() { _bullets++; }

	void Update () {
        //si el sensor encuentra alguna mano, entra al if
        if (_leap.Frame().Hands.Count > 0)
        {
            Hand hand = _leap.Frame().Hands[0];
            //si la mano esta del lado derecho del sensor se  mueve a la derecha
            if (hand.PalmPosition.x > 0) GetComponent<Transform>().Translate(new Vector2(0.25f, 0f));
            //sino a la izquierda
            else GetComponent<Transform>().Translate(new Vector2(-0.25f, 0f));
            //si el usuario cierra el puño la nave dispara
            if (hand.GrabStrength > 0.7f)
            {
                if (_bullets > 0)
                {
                    //el usuario dispone de 3 balas 
                    for (int i = 0; i < 3; i++)
                    {
                        //checa que el usuario tenga balas disponible
                        if (_bala[i].transform.localPosition == _bala[i].GetComponent<Balas>()._initialPos)
                        {
                            _bullets--;
                            _bala[i].transform.localPosition = this.transform.localPosition;
                            //se cambia el valor de la variable onShot para que esta su mueva verticalmente
                            _bala[i].GetComponent<Balas>()._onShot = true;
                            break;
                        }
                    }
                }
            }
        }
        //checa el estado del juego
        if (_lose)
        {
            _endGameMsj.text = "YOU LOSE!";
            Destroy(this.gameObject);
        }
        //si el jugador mata a todos los invaders gana
        if (Balas.getPts() == 1500) _endGameMsj.text = "YOU WIN!";
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        //si la nave choca con un invader, pierde
        if(col.gameObject.tag == "Invader") _lose = true;
    }
}
