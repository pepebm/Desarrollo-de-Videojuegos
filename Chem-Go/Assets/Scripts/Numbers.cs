/*
    Ivan Aram Gonzalez Su A01022584
    Jose Manuel Beauregard Mendez A01021716
    Daniel Esteban Tapia A01022285
*/
//Librerias
using UnityEngine;
using System.Collections;

// Clase para controlar los cubos que tienen el Drag and Drop en el nivel Balance
public class Numbers : MonoBehaviour {
    //Variable para checar si se esta arrastrando un numero
    private bool _dragging;
    //Variable pra checar que tanto se esta arrastrando un numero
    private float _distance;
    //Variable para guardar la posision inicial de cada numero
    private Vector3 _initPos;

    void Start() {
        //Inicializacion de variable _initPos y _dragging
        _initPos = transform.position;
        _dragging = false;
    }

    void Update() {
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

        //Dependiendo en la dificultad actualizamos los cubos en escena
        if (gameController.getDif() == 1) updateEasy();
        else if (gameController.getDif() == 2) updateMedium();
        else if (gameController.getDif() == 3) updateHard();
    }

    //Funcion que se llama cuando presionas el boton del mouse
    void OnMouseDown() {
        //Actualizar variables _distance y _dragging
        _distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        _dragging = true;
    }

    //Funcion que se llama cuando sueltas el boton del mouse
    void OnMouseUp(){
        //Actualizar variable _dragging
        _dragging = false;
        //Regresar la letra a su posicion inicial
        transform.position = _initPos;
    }

    // Funcion para actualizar los cubos de la dificultad facil
    void updateEasy()
    {
        // Validamos la posicion de los cubos
        if (this.transform.localPosition.y >= 20f && this.transform.localPosition.y <= 23f)
        {
            if (this.transform.localPosition.x >= -23.41f && this.transform.localPosition.x <= -20f)
            {
                SceneController.answer(0, this.gameObject.name);
                GameObject.Find("space1").GetComponent<Renderer>().material = GetComponent<Renderer>().material;
            }
            else if (this.transform.localPosition.x >= -16.37f && this.transform.localPosition.x <= -13f)
            {
                SceneController.answer(1, this.gameObject.name);
                GameObject.Find("space2").GetComponent<Renderer>().material = GetComponent<Renderer>().material;
            }
            else if (this.transform.localPosition.x >= -10.33f && this.transform.localPosition.x <= -7f)
            {
                SceneController.answer(2, this.gameObject.name);
                GameObject.Find("space3").GetComponent<Renderer>().material = GetComponent<Renderer>().material;
            }
        }
    }

    // Funcion para actualizar los cubos de la dificultad media
    void updateMedium()
    {
        // Validamos la posicion de los cubos
        if (this.transform.localPosition.y >= 20f && this.transform.localPosition.y <= 23f)
        {
            if (this.transform.localPosition.x >= -26.5f && this.transform.localPosition.x <= -23.5f)
            {
                SceneController.answer(0, this.gameObject.name);
                GameObject.Find("space1").GetComponent<Renderer>().material = GetComponent<Renderer>().material;
            }
            else if (this.transform.localPosition.x >= -20.5f && this.transform.localPosition.x <= -17.5f)
            {
                SceneController.answer(1, this.gameObject.name);
                GameObject.Find("space2").GetComponent<Renderer>().material = GetComponent<Renderer>().material;
            }
            else if (this.transform.localPosition.x >= -14.5f && this.transform.localPosition.x <= -11.5f)
            {
                SceneController.answer(2, this.gameObject.name);
                GameObject.Find("space3").GetComponent<Renderer>().material = GetComponent<Renderer>().material;
            }
            else if (this.transform.localPosition.x >= -8.5f && this.transform.localPosition.x <= -5.5f)
            {
                SceneController.answer(3, this.gameObject.name);
                GameObject.Find("space4").GetComponent<Renderer>().material = GetComponent<Renderer>().material;
            }
        }
    }

    // Funcion para actualizar los cubos de la dificultad dificil
    void updateHard()
    {
        // Validamos la posicion de los cubos
        if (this.transform.localPosition.y >= 20f && this.transform.localPosition.y <= 23f)
        {
            if (this.transform.localPosition.x >= -30.5f && this.transform.localPosition.x <= -27.5f)
            {
                SceneController.answer(0, this.gameObject.name);
                GameObject.Find("space1").GetComponent<Renderer>().material = GetComponent<Renderer>().material;
            }
            else if (this.transform.localPosition.x >= -24.5f && this.transform.localPosition.x <= -21.5f)
            {
                SceneController.answer(1, this.gameObject.name);
                GameObject.Find("space2").GetComponent<Renderer>().material = GetComponent<Renderer>().material;
            }
            else if (this.transform.localPosition.x >= -18.5f && this.transform.localPosition.x <= -15.5f)
            {
                SceneController.answer(2, this.gameObject.name);
                GameObject.Find("space3").GetComponent<Renderer>().material = GetComponent<Renderer>().material;
            }
            else if (this.transform.localPosition.x >= -12.5f && this.transform.localPosition.x <= -9.5f)
            {
                SceneController.answer(3, this.gameObject.name);
                GameObject.Find("space4").GetComponent<Renderer>().material = GetComponent<Renderer>().material;
            }
            else if (this.transform.localPosition.x >= -6.5f && this.transform.localPosition.x <= -3.5f)
            {
                SceneController.answer(4, this.gameObject.name);
                GameObject.Find("space5").GetComponent<Renderer>().material = GetComponent<Renderer>().material;
            }
        }
    }
}
