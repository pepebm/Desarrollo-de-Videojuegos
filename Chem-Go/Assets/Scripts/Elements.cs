/*
    Ivan Aram Gonzalez Su A01022584
    Jose Manuel Beauregard Mendez A01021716
    Daniel Esteban Tapia A01022285
*/
//Librerias
using UnityEngine;
using System.Collections;

// Clase para controlar los cubos que tienen el Drag and Drop en el nivel Periodic Table
public class Elements : MonoBehaviour {
    //Variable para checar si se esta arrastrando un numero
    private bool _dragging;
    //Variable pra checar que tanto se esta arrastrando un numero
    private float _distance;
    //Variable para guardar la posision inicial de cada numero
    private Vector3 _initPos;

    void Start()
    {
        //Inicializacion de variable _initPos y _dragging
        _initPos = transform.position;
        _dragging = false;
    }

    void Update()
    {
        //Modificacion de la posicion de la letra si es que la estan arrastrando
        if (_dragging)
        {
            //Obtenemos la posision del rayo deseado
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(_distance);
            //Congelar la posicion de Z
            rayPoint.z = 0f;
            //Movemos el cubo a la posision calculada
            transform.position = rayPoint;
        }
        if (this.transform.localPosition.x >= -17f && this.transform.localPosition.x <= -15f && (this.transform.localPosition.y > 21f && this.transform.localPosition.y < 23f))
        {
            CompositionController.answer(this.gameObject.name);
            GameObject.Find("space1").GetComponent<Renderer>().material = GetComponent<Renderer>().material;
        }
    }

    //Funcion que se llama cuando presionas el boton del mouse
    void OnMouseDown()
    {
        //Actualizar variables _distance y _dragging
        _distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        _dragging = true;
    }

    //Funcion que se llama cuando sueltas el boton del mouse
    void OnMouseUp()
    {
        //Actualizar variable _dragging
        _dragging = false;
        //Regresar la letra a su posicion inicial
        transform.position = _initPos;
    }
}
