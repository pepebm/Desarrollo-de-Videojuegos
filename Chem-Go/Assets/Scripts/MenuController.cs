/*
    Ivan Aram Gonzalez Su A01022584
    Jose Manuel Beauregard Mendez A01021716
    Daniel Esteban Tapia A01022285
*/
//Librerias
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Clase para interaccion del usuario con nuestro juego
public class MenuController : MonoBehaviour {
    private string level;
    //Variables para identificar que boton esta seleccionado
    public Button[] _lvlButtons;
    public Button[] _difButtons;
    public Button[] _questionButtons;
    
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            gameController.resetScore();
            gameController.setName("Name");
        }
    }

    // Update is called once per frame
    void Update() {}
    
    //Funcion para cambiar de escena
    public void cambiarEscena(string escena)
    {
        SceneManager.LoadScene(escena);
    }

    //Funcion para cerrar la aplicacion
    public void cerrar()
    {
        Application.Quit();
    }

    //Set the game level
    public void setLevel(string lvl)
    {
        level = lvl;
    }

    //Load the game
    public void loadLevel()
    {
        if (level == null) level = "LevelSelection";
        if (gameController.getDif() == 0) gameController.setDif(1);
        if (gameController.getNumPreguntas() == 0) gameController.setNumPreguntas(5);
        SceneManager.LoadScene(level);
    }

    //Funcion para poner el numero de preguntas
    public void numPreguntas(int num)
    {
        gameController.setNumPreguntas(num);
    }

    //Funcion para poner la dificultad
    public void dificulty(int d)
    {
        gameController.setDif(d);
    }

    //Esta funcion va a ser utilizada en la escena de level selection para que solo se selecione un boton por categoria
    public void selected(Button b)
    {
        //La primera categoria seran los botones del tipo de nivel (balanceo o periodic table)
        foreach(Button x in _lvlButtons)
        {
            //Si el boton que activa la funcion esta dentro de esta categoria entra
            if (x.Equals(b))
            {
                //Se pone todos los botones del array en blanco y despues se colorea el que se pico
                for (int i = 0; i < _lvlButtons.Length; i++)
                {
                    _lvlButtons[i].image.color = Color.white;
                }
                b.image.color = Color.yellow;
                return;
            }
        }
        //categoria 2, easy, medium o hard
        foreach (Button x in _difButtons)
        {
            //Si el boton que activa la funcion esta dentro de esta categoria entra
            if (x.Equals(b))
            {
                //Se pone todos los botones del array en blanco y despues se colorea el que se pico
                for (int i = 0; i < _difButtons.Length; i++)
                {
                    _difButtons[i].image.color = Color.white;
                }
                b.image.color = Color.yellow;
                return;
            }
        }

        //categoria 3; 5, 10 o 15
        foreach (Button x in _questionButtons)
        {
            //Si el boton que activa la funcion esta dentro de esta categoria entra
            if (x.Equals(b))
            {
                //Se pone todos los botones del array en blanco y despues se colorea el que se pico
                for (int i = 0; i < _questionButtons.Length; i++)
                {
                    _questionButtons[i].image.color = Color.white;
                }
                b.image.color = Color.yellow;
                return;
            }
        }
    }
}
