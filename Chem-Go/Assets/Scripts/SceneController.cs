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

public class SceneController : MonoBehaviour {
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
    private string[,] _respuestas;
    //Variable para guardar las respuestas del usuario
    private static string[] _userAnswer;
    //Variable para controlar las vidas
    private int _vidas;
    //Cubos de respuestas
    GameObject _space1;
    GameObject _space2;
    GameObject _space3;
    GameObject _space4;
    GameObject _space5;

    void Start() {
        _quetionN.text = "Question: 1/" + gameController.getNumPreguntas();
        //Inicializacion de variable _vidas
        _vidas = 3;
        //Inicializacion de variable _userAnswer
        _userAnswer = new string[5];
        //Inicializacion de variable _reacciones
        _reacciones = new string[15];
        //Inicializacion de variable _randomIdx
        _randomIdx = new int[gameController.getNumPreguntas()];
        //Inicializacion de variable _idx
        _idx = 0;
        //Inizializacion de los cubos usados para las respuestas
        _space1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        _space2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        _space3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        if (gameController.getDif() == 2) _space4 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        else if (gameController.getDif() == 3)
        {
            _space4 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _space5 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        }

        //Configuracion de variables globales
        configureSpaces();
        fillRandomIdx();
    }
	
	void Update () {
        //Actualizacion del texto _reaccion
        _reaccion.text = _reacciones[_randomIdx[_idx]];
	}

    //Funcion para validar la respuesta y aumentarle 1 a _idx y por ende mostrar la siguiente reaccion
    public void nextQuestion()
    {
        for(int i = 0; i < 5; i++)
        {
            if (_userAnswer[i] != _respuestas[_randomIdx[_idx],i])
            {
                // Restamos 25 puntos
                gameController.addScore(-25);
                _score.text = "Score: " + gameController.getScore();
                // Quitamos vida
                if (_vidas > 1) Destroy(GameObject.Find("Vida" + _vidas--));
                else
                {
                    // Lose
                    Destroy(GameObject.Find("Vida" + _vidas));
                    if (gameController.getScore() > 0) gameController.addScoreToBalanceo(gameController.getName(), gameController.getScore());
                    SceneManager.LoadScene(0);
                }
                return;
            }
        }
        // anadimos puntaje dependiendo de la dificultad
        if (gameController.getDif() == 1) gameController.addScore(50);
        else if (gameController.getDif() == 2) gameController.addScore(75);
        else if (gameController.getDif() == 3) gameController.addScore(100);
        _score.text = "Score: " + gameController.getScore();
        
        if (_idx < gameController.getNumPreguntas() - 1)
        {
            for (int i = 0; i < 5; i++) _userAnswer[i] = null;
            _space1.gameObject.GetComponent<Renderer>().material = new Material(Shader.Find("Diffuse"));
            _space2.gameObject.GetComponent<Renderer>().material = new Material(Shader.Find("Diffuse"));
            _space3.gameObject.GetComponent<Renderer>().material = new Material(Shader.Find("Diffuse"));
            if(gameController.getDif() == 2) _space4.gameObject.GetComponent<Renderer>().material = new Material(Shader.Find("Diffuse"));
            else if (gameController.getDif() == 3)
            {
                _space4.gameObject.GetComponent<Renderer>().material = new Material(Shader.Find("Diffuse"));
                _space5.gameObject.GetComponent<Renderer>().material = new Material(Shader.Find("Diffuse"));
            }
            _idx++;
            _quetionN.text = "Question: " + (_idx + 1) + "/" + gameController.getNumPreguntas();
        }
        else
        {
            // Win
            if(gameController.getScore() > 0) gameController.addScoreToBalanceo(gameController.getName(), gameController.getScore());
            SceneManager.LoadScene(0);
        }
    }

    //Funcion utilizada para anadir una respuesta
    public static void answer(int i, string ans)
    {
        _userAnswer[i] = ans;
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

    // LLenar reacciones de la dificultad facil
    private void fillReaccionEasy()
    {
        _reacciones[0] = "HgO -> Hg + O2";
        _reacciones[1] = "H2O -> H + O";
        _reacciones[2] = "Mg + O2 -> MgO";
        _reacciones[3] = "Fe + Cl2 -> FeCl3";
        _reacciones[4] = "N2 + H2 -> NH3";
        _reacciones[5] = "Ag2O -> Ag + O2";
        _reacciones[6] = "Na + Cl -> NaCl";
        _reacciones[7] = "Al + Cl2 -> AlCl3";
        _reacciones[8] = "NaCl -> Na + Cl2";
        _reacciones[9] = "SO2 + O2 -> SO3";
        _reacciones[10] = "N2 + H2 -> NH3";
        _reacciones[11] = "KClO3 -> KCl + O2";
        _reacciones[12] = "NaClO -> NaCl + NaClO3";
        _reacciones[13] = "Cr + O2 -> Cr2O3";
        _reacciones[14] = "Fe3 + S -> FeS";
    }

    // LLenar reacciones de la dificultad medio
    private void fillReaccionMed()
    {
        _reacciones[0] = "KNO2 + O -> KNO2 + O2";
        _reacciones[1] = "Ca + CO3 -> CO2 + CaO";
        _reacciones[2] = "Mg(CN)2 + HCl -> MgCl2 + HCN";
        _reacciones[3] = "KCl + AgNO3 -> KNO3 + AgCl";
        _reacciones[4] = "Ca(HCO3)2 -> CO2 + CaO + H2O";
        _reacciones[5] = "K2CO3 + C -> CO + K";
        _reacciones[6] = "Cr2O3 + Al ->  Al2O3 + Cr";
        _reacciones[7] = "H2SO4 + NaCl -> Na2SO4 + HCl";
        _reacciones[8] = "BaO2 + HCl -> BaCl2 + H2O2";
        _reacciones[9] = "H2O + Na -> Na(OH) + H2";
        _reacciones[10] = "Fe2O3 + CO -> CO2 + Fe";
        _reacciones[11] = "Ag2SO4 + NaCl -> Na2SO4 + AgCl";
        _reacciones[12] = "Na2CO3 + H2O  + CO2 -> NaHCO3";
        _reacciones[13] = "NaNO3 + KCl -> NaCl + KNO3";
        _reacciones[14] = "F2 + H20 -> HF + O3";
    }

    // LLenar reacciones de la dificultad dificil
    private void fillReaccionHard()
    {
        _reacciones[0] = "HNO3 + H2S -> NO + S + H20";
        _reacciones[1] = "Cu + HNO3 -> Cu(NO3)2 + NO + H2O";
        _reacciones[2] = "NH3 + CuO -> H2O + N2 + Cu";
        _reacciones[3] = "Al + NaOH + H2O -> NaAlO2 + H2";
        _reacciones[4] = "Na2CO3 + HCl -> NaCl + H2O + CO2";
        _reacciones[5] = "NaOH + I2 -> NaI + NaIO3 + H2O";
        _reacciones[6] = "KI + FeCl3 -> FeCl2 + KCl + I2";
        _reacciones[7] = "NH3 + NaClO -> N2H4 + NaCl + H2O";
        _reacciones[8] = "HNO3 + HCl -> NO + H2O + Cl2";
        _reacciones[9] = "HCl + SnCl2 + O3 -> SnCl4 + H2O";
        _reacciones[10] = "PH3 + I2 + H20 -> H3PO2 + HI";
        _reacciones[11] = "H2SO4 + HI -> S + I2 + H20";
        _reacciones[12] = "MnO2 + HCl -> MnCl2 + Cl2 + H2O";
        _reacciones[13] = "AgNO3 + Cl2 -> AgCl + N2O3 + O2";
        _reacciones[14] = "F2O + NaOH -> NaF + O2 + H2O";
    }

    //Funcion para configurar los espacias de las respuestas
    private void configureSpaces()
    {
        _space1.AddComponent<BoxCollider>();
        _space1.gameObject.name = "space1";
        _space1.transform.localEulerAngles = new Vector3(0f, 180f, 0f);

        _space2.AddComponent<BoxCollider>();
        _space2.gameObject.name = "space2";
        _space2.transform.localEulerAngles = new Vector3(0f, 180f, 0f);

        _space3.AddComponent<BoxCollider>();
        _space3.gameObject.name = "space3";
        _space3.transform.localEulerAngles = new Vector3(0f, 180f, 0f);

        //Configuracion de los espacios y de las reacciones de la dificultad facil
        if (gameController.getDif() == 1)
        {
            fillReaccionEasy();
            fillAnswersEasy();
            configureSpacesEasy();
        }

        //Configuracion de los espacios y de las reacciones de la dificultad media
        else if (gameController.getDif() == 2)
        {
            fillReaccionMed();
            fillAnswersMed();
            configureSpacesMedium();
        }

        //Configuracion de los espacios y de las reacciones de la dificultad dificil
        else if (gameController.getDif() == 3)
        {
            fillReaccionHard();
            fillAnswersHar();
            configureSpacesHard();
        }
    }

    // Funcion para configurar los cubos de respuesta de la dificultad facil
    private void configureSpacesEasy()
    {
        _space1.transform.localPosition = new Vector3(-21.41f, 21.5f, 0f);
        _space1.transform.localScale = new Vector3(3f, 3f, 3f);

        _space2.transform.localPosition = new Vector3(-15.37f, 21.5f, 0f);
        _space2.transform.localScale = new Vector3(3f, 3f, 3f);

        _space3.transform.localPosition = new Vector3(-9.33f, 21.5f, 0f);
        _space3.transform.localScale = new Vector3(3f, 3f, 3f);
    }

    // Funcion para configurar los cubos de respuesta de la dificultad media
    private void configureSpacesMedium()
    {
        _space4.AddComponent<BoxCollider>();
        _space4.gameObject.name = "space4";
        _space4.transform.localEulerAngles = new Vector3(0f, 180f, 0f);

        _space1.transform.localPosition = new Vector3(-25f, 21.5f, 0f);
        _space1.transform.localScale = new Vector3(3f, 3f, 3f);

        _space2.transform.localPosition = new Vector3(-19f, 21.5f, 0f);
        _space2.transform.localScale = new Vector3(3f, 3f, 3f);

        _space3.transform.localPosition = new Vector3(-13f, 21.5f, 0f);
        _space3.transform.localScale = new Vector3(3f, 3f, 3f);

        _space4.transform.localPosition = new Vector3(-7f, 21.5f, 0f);
        _space4.transform.localScale = new Vector3(3f, 3f, 3f);
    }

    // Funcion para configurar los cubos de respuesta de la dificultad dificil
    private void configureSpacesHard()
    {
        _space4.AddComponent<BoxCollider>();
        _space4.gameObject.name = "space4";
        _space4.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
        _space5.AddComponent<BoxCollider>();
        _space5.gameObject.name = "space5";
        _space5.transform.localEulerAngles = new Vector3(0f, 180f, 0f);

        _space1.transform.localPosition = new Vector3(-29f, 21.5f, 0f);
        _space1.transform.localScale = new Vector3(3f, 3f, 3f);

        _space2.transform.localPosition = new Vector3(-23f, 21.5f, 0f);
        _space2.transform.localScale = new Vector3(3f, 3f, 3f);

        _space3.transform.localPosition = new Vector3(-17f, 21.5f, 0f);
        _space3.transform.localScale = new Vector3(3f, 3f, 3f);

        _space4.transform.localPosition = new Vector3(-11f, 21.5f, 0f);
        _space4.transform.localScale = new Vector3(3f, 3f, 3f);

        _space5.transform.localPosition = new Vector3(-5f, 21.5f, 0f);
        _space5.transform.localScale = new Vector3(3f, 3f, 3f);
    }

    //LLenar las respuestas de la dificultad facil
    private void fillAnswersEasy()
    {
        _respuestas = new string[15, 5]{ {"n2", "n2", "n1", null, null},
                                        {"n1", "n2", "n1", null, null},
                                        {"n2", "n1", "n2", null, null},
                                        {"n2", "n3", "n2", null, null},
                                        {"n1", "n3", "n2", null, null},
                                        {"n2", "n4", "n1", null, null},
                                        {"n1", "n1", "n1", null, null},
                                        {"n2", "n3", "n2", null, null},
                                        {"n2", "n2", "n1", null, null},
                                        {"n2", "n1", "n2", null, null},
                                        {"n1", "n3", "n2", null, null},
                                        {"n2", "n2", "n3", null, null},
                                        {"n3", "n2", "n1", null, null},
                                        {"n4", "n3", "n2", null, null},
                                        {"n1", "n3", "n3", null, null}
                                        };

    }

    //LLenar las respuestas de la dificultad media
    private void fillAnswersMed()
    {
        _respuestas = new string[15, 5]{ {"n1", "n2", "n1", "n1", null},
                                         {"n1", "n1", "n1", "n1", null},
                                         {"n1", "n2", "n1", "n2", null},
                                         {"n1", "n1", "n1", "n1", null},
                                         {"n1", "n2", "n1", "n1", null},
                                         {"n1", "n2", "n3", "n2", null},
                                         {"n1", "n2", "n1", "n2", null},
                                         {"n1", "n2", "n1", "n2", null},
                                         {"n1", "n2", "n1", "n1", null},
                                         {"n2", "n2", "n2", "n1", null},
                                         {"n1", "n3", "n3", "n2", null},
                                         {"n1", "n2", "n1", "n2", null},
                                         {"n1", "n1", "n1", "n2", null},
                                         {"n1", "n1", "n1", "n1", null},
                                         {"n3", "n3", "n6", "n1", null}
                                         };
    }

    //LLenar las respuestas de la dificultad dificil
    private void fillAnswersHar() 
    {
    _respuestas = new string[15, 5]{ {"n2", "n3", "n2", "n3", "n4"},
                                     {"n3", "n8", "n3", "n2", "n4"},
                                     {"n2", "n3", "n3", "n1", "n3"},
                                     {"n2", "n2", "n2", "n2", "n3"},
                                     {"n1", "n2", "n2", "n1", "n1"},
                                     {"n6", "n3", "n5", "n1", "n3"},
                                     {"n2", "n2", "n2", "n2", "n1"},
                                     {"n2", "n1", "n1", "n1", "n1"},
                                     {"n2", "n6", "n2", "n4", "n3"},
                                     {"n6", "n3", "n1", "n3", "n3"},
                                     {"n1", "n2", "n2", "n1", "n4"},
                                     {"n1", "n6", "n1", "n3", "n4"},
                                     {"n1", "n4", "n1", "n1", "n2"},
                                     {"n1", "n2", "n4", "n2", "n3"},
                                     {"n1", "n2", "n2", "n1", "n1"}
                                     };
    }
    
}
