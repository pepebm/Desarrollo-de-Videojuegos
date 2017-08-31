/*
    Ivan Aram Gonzalez Su A01022584
    Jose Manuel Beauregard Mendez A01021716
    Daniel Esteban Tapia A01022285
*/
//Librerias
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Highscores controller class
public class HighscoresController : MonoBehaviour
{
    // Textos en los cuales se guardaran las puntuaciones mas altas de ambos niveles
    public Text _firstB;
    public Text _secondB;
    public Text _thirdB;
    public Text _firstT;
    public Text _secondT;
    public Text _thirdT;
    
    void Start()
    {
        //Mostrar puntuaciones mas altas del nivel de balanceo
        if (gameController.getThirdB().Key == null)
        {
            if (gameController.getSecondB().Key == null)
            {
                if (gameController.getFirstB().Key == null) showMessageB();
                else showFirstB();
            }
            else showSecondB();
        }
        else showThirdB();

        //Mostrar puntuaciones mas altas del nivel de tabla periodica
        if (gameController.getThirdT().Key == null)
        {
            if (gameController.getSecondT().Key == null)
            {
                if (gameController.getFirstT().Key == null) showMessageT();
                else showFirstT();
            }
            else showSecondT();
        }
        else showThirdT();
    }
    
    void Update() { }

    //Funcion para solo mostrar la puntuacion mas alta del nivel Balance
    void showFirstB()
    {
        _firstB.text = "1. " + gameController.getFirstB().Key + ": " + gameController.getFirstB().Value;
    }

    //Funcion para mostrar las 2 puntuaciones mas altas del nivel Balance
    void showSecondB()
    {
        _firstB.text = "1. " + gameController.getFirstB().Key + ": " + gameController.getFirstB().Value;
        _secondB.text = "2. " + gameController.getSecondB().Key + ": " + gameController.getSecondB().Value;
    }

    //Funcion para mostrar las 3 puntuaciones mas altas del nivel Balance
    void showThirdB()
    {
        _firstB.text = "1. " + gameController.getFirstB().Key + ": " + gameController.getFirstB().Value;
        _secondB.text = "2. " + gameController.getSecondB().Key + ": " + gameController.getSecondB().Value;
        _thirdB.text = "3. " + gameController.getThirdB().Key + ": " + gameController.getThirdB().Value;
    }

    //Funcion para solo mostrar la puntuacion mas alta del nivel Periodic Table
    void showFirstT()
    {
        _firstT.text = "1. " + gameController.getFirstT().Key + ": " + gameController.getFirstT().Value;
    }

    //Funcion para mostrar las 2 puntuaciones mas altas del nivel Periodic Table
    void showSecondT()
    {
        _firstT.text = "1. " + gameController.getFirstT().Key + ": " + gameController.getFirstT().Value;
        _secondT.text = "2. " + gameController.getSecondT().Key + ": " + gameController.getSecondT().Value;
    }

    //Funcion para mostrar las 3 puntuaciones mas altas del nivel Periodic Table
    void showThirdT()
    {
        _firstT.text = "1. " + gameController.getFirstT().Key + ": " + gameController.getFirstT().Value;
        _secondT.text = "2. " + gameController.getSecondT().Key + ": " + gameController.getSecondT().Value;
        _thirdT.text = "3. " + gameController.getThirdT().Key + ": " + gameController.getThirdT().Value;
    }

    //Enviar un mensaje si es que todavia no hay puntuaciones en el nivel Balance
    void showMessageB()
    {
        _secondB.text = "There are no highscores to display :(";
    }

    //Enviar un mensaje si es que todavia no hay puntuaciones en el nivel Periodic Table
    void showMessageT()
    {
        _secondT.text = "There are no highscores to display :(";
    }
}