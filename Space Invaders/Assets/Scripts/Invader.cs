/*
    Ivan Aram Gonzalez Su A01022584
    Jose Manuel Beauregard Mendez A01021716
    Daniel Esteban Tapia A01022285
*/
// Librerías para Unity
using UnityEngine;
using System.Collections;


public class Invader : MonoBehaviour {
    //objeto de la bala enemiga
    private GameObject _bullet;
    //variable que gardara la posicion inicial de la bala enemiga
    private Vector2 _x;
    //variable que determinara si el enemigo puede disparar
    public bool _dispara;

    // Use this for initialization
    void Start () {
        _x = new Vector2(0f, 6f);
        this.gameObject.AddComponent<Rigidbody2D>();
        this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        //si el invader tiene la capacidad de disparar se crea su bala
        if (_dispara)
        {
            _bullet = new GameObject();
            _bullet.AddComponent<SpriteRenderer>();
            _bullet.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("balainvader");
            _bullet.AddComponent<PolygonCollider2D>();
            _bullet.AddComponent<balainvader>();
            _bullet.GetComponent<SpriteRenderer>().sortingLayerName = "Objetos";
            _bullet.transform.localScale = new Vector2(0.1f, 0.1f);
            _bullet.transform.localPosition = _x;
            _bullet.GetComponent<SpriteRenderer>().tag = "Invader";
        }
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Transform>().Translate(new Vector2(0f, -0.01f));
        if(_dispara) rand_bullet();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //si el invader toca el piso el  juego acaba y el jugador pierde
        if (col.gameObject.name == "piso")
        {
            Disparar._lose = true;
            Destroy(this.gameObject);
        }
    }
    //esta funcion generara las balas de manera aleatoria con un tengo entr 0 a 200
    private void rand_bullet()
    {
        //si el invader puede disparar y se genera el numero 0 con random, el invader dispara
        if (this && _bullet && Random.Range(0,200) == 0)
        {
            _bullet.transform.localPosition = transform.localPosition;
            //se manda a llamar una variable del script balainvader que la convierte a true, ver ese script para mas detalles
            _bullet.GetComponent<balainvader>()._onShot = true;
        }
    }
}
