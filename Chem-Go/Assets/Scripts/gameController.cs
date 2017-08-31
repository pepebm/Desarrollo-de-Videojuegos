/*
    Ivan Aram Gonzalez Su A01022584
    Jose Manuel Beauregard Mendez A01021716
    Daniel Esteban Tapia A01022285
*/
//Librerias
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class gameController : MonoBehaviour
{
    //Variable para que solo haya un Controller
    private bool _esteEsElBueno = false;
    //Variable para guardar la dificultad (1 = facil, 2 = medio, 3 = dificil)
    private static int _dificultad;
    //Variable para guardar el numero de preguntas
    private static int _numPreguntas;
    //Variable para guardar puntuacion
    private static int _score;
    //Variable para guardar el nombre del juegador
    private static string _name;
    //Variables para guardas las 3 puntuaciones mas altas del nivel balanceo
    private static KeyValuePair<string, int> _firstB;
    private static KeyValuePair<string, int> _secondB;
    private static KeyValuePair<string, int> _thirdB;
    //Variables para guardas las 3 puntuaciones mas altas del nivel Tabla periodica
    private static KeyValuePair<string, int> _firstT;
    private static KeyValuePair<string, int> _secondT;
    private static KeyValuePair<string, int> _thirdT;

    //Aqui eliminamos todas las copias de gameController
    void Awake(){
        //Eliminacion de los gameControllers repetidos
        gameController[] controllers = FindObjectsOfType<gameController>();
        if (controllers.Length == 1)
        {
            _esteEsElBueno = true;
            DontDestroyOnLoad(this);
        }
        else
        {
            foreach (gameController c in controllers)
            {
                if (c._esteEsElBueno) Destroy(this.gameObject);
                return;
            }
        }
    }

    void Start()
    {
        // Inicializamos variables
        _name = "Name";
        _dificultad = 0;
        _numPreguntas = 0;
        _score = 0;
        _firstB = new KeyValuePair<string, int>(null, 0);
        _secondB = new KeyValuePair<string, int>(null, 0);
        _thirdB = new KeyValuePair<string, int>(null, 0);
        _firstT = new KeyValuePair<string, int>(null, 0);
        _secondT = new KeyValuePair<string, int>(null, 0);
        _thirdT = new KeyValuePair<string, int>(null, 0);
    }

    // Update is called once per frame
    void Update(){}

    //Get y Set de la dificultad
    public static void setDif(int d) { _dificultad = d; }
    public static int getDif() { return _dificultad; }

    //Get y Set del numero de preguntas
    public static void setNumPreguntas(int p) { _numPreguntas = p; }
    public static int getNumPreguntas() { return _numPreguntas; }

    //Anadir puntuacion
    public static void resetScore() { _score = 0; }
    public static void addScore(int s) { _score += s; }
    public static int getScore() { return _score; }

    //Set y Get de la variable name
    public static string getName() { return _name; }
    public static void setName(string n){ _name = n; }

    //Gets the las puntuaciones mas altas del nivel Balance
    public static KeyValuePair<string, int> getFirstB() { return _firstB; }
    public static KeyValuePair<string, int> getSecondB() { return _secondB; }
    public static KeyValuePair<string, int> getThirdB() { return _thirdB; }

    //Anadir una puntuacion a las puntuaciones altas del nivel Balance
    public static void addScoreToBalanceo(string name, int score)
    {
        if (_thirdB.Value < score)
        {
            if (_secondB.Value < score)
            {
                if (_firstB.Value < score)
                {
                    _thirdB = _secondB;
                    _secondB = _firstB;
                    _firstB = new KeyValuePair<string, int>(name, score);
                }
                else
                {
                    _thirdB = _secondB;
                    _secondB = new KeyValuePair<string, int>(name, score);
                }
            }
            else _thirdB = new KeyValuePair<string, int>(name, score);
        }
    }

    //Gets the las puntuaciones mas altas del nivel Periodic Table
    public static KeyValuePair<string, int> getFirstT() { return _firstT; }
    public static KeyValuePair<string, int> getSecondT() { return _secondT; }
    public static KeyValuePair<string, int> getThirdT() { return _thirdT; }

    //Anadir una puntuacion a las puntuaciones altas del nivel Periodic Table
    public static void addScoreToTablaPeriodica(string name, int score)
    {
        if (_thirdT.Value < score)
        {
            if (_secondT.Value < score)
            {
                if (_firstT.Value < score)
                {
                    _thirdT = _secondT;
                    _secondT = _firstT;
                    _firstT = new KeyValuePair<string, int>(name, score);
                }
                else
                {
                    _thirdT = _secondT;
                    _secondT = new KeyValuePair<string, int>(name, score);
                }
            }
            else _thirdT = new KeyValuePair<string, int>(name, score);
        }
    }

    // Funcion para pausar o poner la musica (tanto de Settings como la opcion de los niveles para pausar la musica)
    public void pauseMusic()
    {
        if (GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().Pause();
            if (SceneManager.GetActiveScene().name == "Balanceo" || SceneManager.GetActiveScene().name == "Composicion")
            {
                GameObject.Find("Sound").GetComponent<Image>().sprite = Resources.Load<Sprite>("sound");
            }
            else
            {
                GameObject.Find("PPbutton").GetComponent<Image>().sprite = Resources.Load<Sprite>("play");
            }
        }
        else
        {
            GetComponent<AudioSource>().Play();
            if (SceneManager.GetActiveScene().name == "Balanceo" || SceneManager.GetActiveScene().name == "Composicion")
            {
                GameObject.Find("Sound").GetComponent<Image>().sprite = Resources.Load<Sprite>("mute");
            }
            else
            {
                GameObject.Find("PPbutton").GetComponent<Image>().sprite = Resources.Load<Sprite>("pause");
            }
        }
    }

    //Funcion para modificar el volumen (a traves del sound controller)
    public void volumen(float n)
    {
        GetComponent<AudioSource>().volume += n;
    }
}
