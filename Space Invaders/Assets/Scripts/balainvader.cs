/*
    Ivan Aram Gonzalez Su A01022584
    Jose Manuel Beauregard Mendez A01021716
    Daniel Esteban Tapia A01022285
*/
// Librerías para Unity
using UnityEngine;
using System.Collections;

public class balainvader : MonoBehaviour
{
    //variable que nos dara control sobre la bala
    public bool _onShot;


    // Use this for initialization
    void Start()
    {
        _onShot = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_onShot) GetComponent<Transform>().Translate(new Vector2(0f, -0.2f));
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        //si la bala enemiga toca el piso entonces se reggresa el objecto a su posicion inicial
        if (col.gameObject.name == "piso")
        {
            this.transform.localPosition = new Vector2(0f, 6f);
        }
            
    }
}
