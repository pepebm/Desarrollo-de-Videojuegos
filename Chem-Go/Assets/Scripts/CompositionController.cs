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

// Controlador del nivel Periodic Table
public class CompositionController : MonoBehaviour {
    //Variable para guardar las reacciones
    private string[] _reacciones;
    //Variable que guarda numeros enteros aleatorios sin repeticion
    private int[] _randomIdx;
    //Variable para recorrer _randomIdx
    private int _idx;
    //Variable para mostrar la puntuacion
    public Text _score;
    //Variable para controlar el texto "Reacciones"
    public Text _reaccion;
    //Variable para mostrar el numero de pregunta en la que va el usuario
    public Text _quetionN;
    //Variable que guarda las respuestas de las reacciones
    private string[] _respuestas;
    //Variable para guardar las respuestas del usuario
    private static string _userAnswer;
    //Variable para controlar las vidas
    private int _vidas;
    //Cubo de respuestas
    GameObject _space1;
    //Cubos de opciones
    GameObject _option1;
    GameObject _option2;
    GameObject _option3;
    GameObject _option4;
    GameObject _option5;

    // Use this for initialization
    void Start()
    {
        // Inicializacion del texto _questionN
        _quetionN.text = "Question: 1/" + gameController.getNumPreguntas();
        //Inicializacion de variable _respuestas
        _respuestas = new string[15];
        //Inicializacion de variable _userAnswer
        _userAnswer = null;
        //Inicializacion de variable _vidas
        _vidas = 3;
        //Inicializacion de variable _reacciones
        _reacciones = new string[15];
        //Inicializacion de variable _randomIdx
        _randomIdx = new int[gameController.getNumPreguntas()];
        //Inicializacion de variable _idx
        _idx = 0;
        //Inicializacion de los 3 cubos usados para las respuestas
        _space1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //Inicializar las opciones
        _option1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        _option2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        _option3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        _option4 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        _option5 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //Inicilizacion de las opciones
        initializeOptions();
        //Configuracion de variables globales
        configureSpaces();
        // Funcion para llenar el arreglo _randomIdx con numeros aleatorios
        fillRandomIdx();
        //Funcion para configurar los cubos donde apareceran las opciones
        configureOptions();
    }

    // Funcion para inicializacion de los cubos donde apareceran las opciones
    private void initializeOptions()
    {
        // Anadimos collider
        _option1.AddComponent<BoxCollider>();
        _option2.AddComponent<BoxCollider>();
        _option3.AddComponent<BoxCollider>();
        _option4.AddComponent<BoxCollider>();
        _option5.AddComponent<BoxCollider>();
        // Anadimos Script Elements
        _option1.AddComponent<Elements>();
        _option2.AddComponent<Elements>();
        _option3.AddComponent<Elements>();
        _option4.AddComponent<Elements>();
        _option5.AddComponent<Elements>();
        // Configuramos la posicion de cada cubo
        _option1.transform.position = new Vector3(-24.5f,17f,0f);
        _option2.transform.position = new Vector3(-20.5f, 17f, 0f);
        _option3.transform.position = new Vector3(-16.5f, 17f, 0f);
        _option4.transform.position = new Vector3(-12.5f, 17f, 0f);
        _option5.transform.position = new Vector3(-8.5f, 17f, 0f);
        // Configuramos la escala de cada cubo
        _option1.transform.localScale = new Vector3(2f, 2f, 2f);
        _option2.transform.localScale = new Vector3(2f, 2f, 2f);
        _option3.transform.localScale = new Vector3(2f, 2f, 2f);
        _option4.transform.localScale = new Vector3(2f, 2f, 2f);
        _option5.transform.localScale = new Vector3(2f, 2f, 2f);
        // Configuramos la rotacion de cada cubo
        _option1.transform.localEulerAngles = new Vector3(0f, 0f, 180f);
        _option2.transform.localEulerAngles = new Vector3(0f, 0f, 180f);
        _option3.transform.localEulerAngles = new Vector3(0f, 0f, 180f);
        _option4.transform.localEulerAngles = new Vector3(0f, 0f, 180f);
        _option5.transform.localEulerAngles = new Vector3(0f, 0f, 180f);
    }

    //Funcion para configurar el material de los cubos de opciones
    // En esta funcion se calculan 5 numeros al azar entre 0 y 14 que son los indices de las respuestas que apareceran en las opciones
    private void configureOptions()
    {
        int[] options = new int[5];
        int idxOfgood = Random.Range(0, 5);
        options[idxOfgood] = _randomIdx[_idx];
        int a;
        int k = 0;
        bool flag;
        //Ciclo para llenar _randomIdx con numeros aleatorios diferentes
        while (k < options.Length)
        {
            if (k == idxOfgood) k += 1;
            else
            {
                flag = false;
                a = Random.Range(0, 15);
                if (a != _randomIdx[_idx]) 
                {
                    for (int j = 0; j < k; j++)
                    {
                        if (options[j] == a)
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (!flag) options[k++] = a;
                }
            }
        }
        // Ponemos el nombre de cada cubo de opcion
        _option1.gameObject.name = _respuestas[options[0]];
        _option2.gameObject.name = _respuestas[options[1]];
        _option3.gameObject.name = _respuestas[options[2]];
        _option4.gameObject.name = _respuestas[options[3]];
        _option5.gameObject.name = _respuestas[options[4]];

        //Anadimos el material de los elementos de la dificultad facil
        if (gameController.getDif() == 1)
        {
            _option1.GetComponent<Renderer>().material = Resources.Load<Material>("Easy/Materials/" + _respuestas[options[0]]);
            _option2.GetComponent<Renderer>().material = Resources.Load<Material>("Easy/Materials/" + _respuestas[options[1]]);
            _option3.GetComponent<Renderer>().material = Resources.Load<Material>("Easy/Materials/" + _respuestas[options[2]]);
            _option4.GetComponent<Renderer>().material = Resources.Load<Material>("Easy/Materials/" + _respuestas[options[3]]);
            _option5.GetComponent<Renderer>().material = Resources.Load<Material>("Easy/Materials/" + _respuestas[options[4]]);
        }
        //Anadimos el material de los elementos de la dificultad medio
        else if (gameController.getDif() == 2)
        {
            _option1.GetComponent<Renderer>().material = Resources.Load<Material>("Medium/Materials/" + _respuestas[options[0]]);
            _option2.GetComponent<Renderer>().material = Resources.Load<Material>("Medium/Materials/" + _respuestas[options[1]]);
            _option3.GetComponent<Renderer>().material = Resources.Load<Material>("Medium/Materials/" + _respuestas[options[2]]);
            _option4.GetComponent<Renderer>().material = Resources.Load<Material>("Medium/Materials/" + _respuestas[options[3]]);
            _option5.GetComponent<Renderer>().material = Resources.Load<Material>("Medium/Materials/" + _respuestas[options[4]]);
        }
        //Anadimos el material de los elementos de la dificultad dificil
        else if (gameController.getDif() == 3)
        {
            _option1.GetComponent<Renderer>().material = Resources.Load<Material>("Hard/Materials/" + _respuestas[options[0]]);
            _option2.GetComponent<Renderer>().material = Resources.Load<Material>("Hard/Materials/" + _respuestas[options[1]]);
            _option3.GetComponent<Renderer>().material = Resources.Load<Material>("Hard/Materials/" + _respuestas[options[2]]);
            _option4.GetComponent<Renderer>().material = Resources.Load<Material>("Hard/Materials/" + _respuestas[options[3]]);
            _option5.GetComponent<Renderer>().material = Resources.Load<Material>("Hard/Materials/" + _respuestas[options[4]]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Actualizacion del texto _reaccion
        _reaccion.text = _reacciones[_randomIdx[_idx]];
    }

    //Funcion para validar la respuesta y aumentarle 1 a _idx y por ende mostrar la siguiente reaccion
    public void nextQuestion()
    {
        //Validar la respuesta
        if (_userAnswer != _respuestas[_randomIdx[_idx]])
        {
            // Restar 25 puntos
            gameController.addScore(-25);
            _score.text = "Score: " + gameController.getScore();
            // Restar vidas
            if (_vidas > 1) Destroy(GameObject.Find("Vida" + _vidas--));
            else
            {
                // Lose
                Destroy(GameObject.Find("Vida" + _vidas));
                if (gameController.getScore() > 0) gameController.addScoreToTablaPeriodica(gameController.getName(), gameController.getScore());
                SceneManager.LoadScene(0);
            }
            return;
        }
        // anadimos puntaje dependiendo de la dificultad
        if (gameController.getDif() == 1) gameController.addScore(50);
        else if (gameController.getDif() == 2) gameController.addScore(75);
        else if (gameController.getDif() == 3) gameController.addScore(100);
        _score.text = "Score: " + gameController.getScore();
        _quetionN.text = "Question: " + (_idx+1) + "/" + gameController.getNumPreguntas();
        if (_idx < gameController.getNumPreguntas() - 1)
        {
            _userAnswer = null;
            _space1.gameObject.GetComponent<Renderer>().material = new Material(Shader.Find("Diffuse"));
            _idx++;
            configureOptions();
        }
        else
        {
            // Win
            if (gameController.getScore() > 0) gameController.addScoreToTablaPeriodica(gameController.getName(), gameController.getScore());
            SceneManager.LoadScene(0);
        }
    }

    //Funcion utilizada para anadir una respuesta
    public static void answer(string ans)
    {
        _userAnswer = ans;
    }

    //Funcion para llenar _randomIdx
    private void fillRandomIdx()
    {
        //Variables locales para llenar _randomIdx
        int a, k = 0;
        bool flag;
        //Ciclo para llenar _randomIdx con numeros aleatorios diferentes
        while (k < _randomIdx.Length)
        {
            flag = false;
            a = Random.Range(0, 15);
            for (int j = 0; j < k; j++)
            {
                if (_randomIdx[j] == a)
                {
                    flag = true;
                    break;
                }
            }
            if (!flag) _randomIdx[k++] = a;
        }
    }
    // Llenar las reacciones que apareceran en la dificultad facil
    private void fillReaccionEasy()
    {
        _reacciones[0] = "Aluminium:";
        _reacciones[1] = "Beryllium:";
        _reacciones[2] = "Carbon:";
        _reacciones[3] = "Calcium:";
        _reacciones[4] = "Chlorine:";
        _reacciones[5] = "Fluorine:";
        _reacciones[6] = "Hydrogen:";
        _reacciones[7] = "Iodine:";
        _reacciones[8] = "Potassium:";
        _reacciones[9] = "Lithium:";
        _reacciones[10] = "Magnesium:";
        _reacciones[11] = "Nitrogen:";
        _reacciones[12] = "Sodium:";
        _reacciones[13] = "Oxygen:";
        _reacciones[14] = "Phosphorus:";
    }

    // Llenar las reacciones que apareceran en la dificultad media
    private void fillReaccionMedium()
    {
        _reacciones[0] = "Argon:";
        _reacciones[1] = "Gold:";
        _reacciones[2] = "Boron:";
        _reacciones[3] = "Barium:";
        _reacciones[4] = "Caesium:";
        _reacciones[5] = "Francium:";
        _reacciones[6] = "Mercury:";
        _reacciones[7] = "Radium:";
        _reacciones[8] = "Rubidium:";
        _reacciones[9] = "Radon:";
        _reacciones[10] = "Sulfur:";
        _reacciones[11] = "Strontium:";
        _reacciones[12] = "Xenon:";
        _reacciones[13] = "Yttrium:";
        _reacciones[14] = "Zinc:";
    }

    // Llenar las reacciones que apareceran en la dificultad dificil
    private void fillReaccionHard()
    {
        _reacciones[0] = "Astatine:";
        _reacciones[1] = "Bohrium:";
        _reacciones[2] = "Cobalt:";
        _reacciones[3] = "Chromium:";
        _reacciones[4] = "Dubnium:";
        _reacciones[5] = "Dysprosium:";
        _reacciones[6] = "Europium:";
        _reacciones[7] = "Manganese:";
        _reacciones[8] = "Neptunium:";
        _reacciones[9] = "Antimony";
        _reacciones[10] = "Seaborgium:";
        _reacciones[11] = "Titanium:";
        _reacciones[12] = "Thallium:";
        _reacciones[13] = "Uranium:";
        _reacciones[14] = "Vanadium:";
    }

    //Funcion para configurar los espacias de las respuestas
    private void configureSpaces()
    {
        _space1.AddComponent<BoxCollider>();
        _space1.gameObject.name = "space1";
        _space1.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
        _space1.transform.localPosition = new Vector3(-16f,22f,0f);
        _space1.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);

        //Configuracion de los espacios y de las reacciones de la dificultad facil
        if (gameController.getDif() == 1)
        {
            fillReaccionEasy();
            fillAnswersEasy();
        }

        //Configuracion de los espacios y de las reacciones de la dificultad media
        else if (gameController.getDif() == 2)
        {
            fillReaccionMedium();
            fillAnswersMedium();
        }

        //Configuracion de los espacios y de las reacciones de la dificultad dificil
        else if (gameController.getDif() == 3)
        {
            fillReaccionHard();
            fillAnswersHard();
        }
    }

    //Funcion para llenar respuestas de la dificultad facil
    private void fillAnswersEasy()
    {
        _respuestas[0] = "al";
        _respuestas[1] = "Be";
        _respuestas[2] = "C";
        _respuestas[3] = "Ca";
        _respuestas[4] = "Cl";
        _respuestas[5] = "F";
        _respuestas[6] = "H";
        _respuestas[7] = "I";
        _respuestas[8] = "K";
        _respuestas[9] = "Li";
        _respuestas[10] = "Mg";
        _respuestas[11] = "N";
        _respuestas[12] = "Na";
        _respuestas[13] = "O";
        _respuestas[14] = "P";
    }

    //Funcion para llenar respuestas de la dificultad media
    private void fillAnswersMedium()
    {
        _respuestas[0] = "Ar";
        _respuestas[1] = "Au";
        _respuestas[2] = "B";
        _respuestas[3] = "Ba";
        _respuestas[4] = "Cs";
        _respuestas[5] = "Fr";
        _respuestas[6] = "Hg";
        _respuestas[7] = "Ra";
        _respuestas[8] = "Rb";
        _respuestas[9] = "Rn";
        _respuestas[10] = "S";
        _respuestas[11] = "Sr";
        _respuestas[12] = "Xe";
        _respuestas[13] = "Y";
        _respuestas[14] = "Zn";
    }

    //Funcion para llenar respuestas de la dificultad dificil
    private void fillAnswersHard()
    {
        _respuestas[0] = "At";
        _respuestas[1] = "Bh";
        _respuestas[2] = "Co";
        _respuestas[3] = "Cr";
        _respuestas[4] = "Db";
        _respuestas[5] = "Dy";
        _respuestas[6] = "Eu";
        _respuestas[7] = "Mn";
        _respuestas[8] = "NP";
        _respuestas[9] = "Sb";
        _respuestas[10] = "Sg";
        _respuestas[11] = "Ti";
        _respuestas[12] = "Tl";
        _respuestas[13] = "U";
        _respuestas[14] = "V";
    }
}
