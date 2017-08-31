/*
    Ivan Aram Gonzalez Su A01022584
    Jose Manuel Beauregard Mendez A01021716
    Daniel Esteban Tapia A01022285
*/
//Librerias
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Clase para recibir el nombre del usuario a traves del InputField
public class UserInputtttt : MonoBehaviour {
    //Variable del campo de entrada
    public InputField _userInput;
    
    void Start () {
        // Inicializacion del evento
        InputField.SubmitEvent submit = new InputField.SubmitEvent();
        // "Escuchar" el evento "setName" de gameCotnroller
        submit.AddListener(gameController.setName);
        _userInput.onEndEdit = submit;
	}

    void Update(){}
}
