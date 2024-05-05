using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    Text scoreTextUI;
    int score;

    public int Score
    {
        get
        {
            return this.score;
        }
        set
        {
            this.score = value;
            UpdateScoreTextUI();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Obtenemos la referencia al componente Text
        scoreTextUI = GetComponent<Text>();
    }

    // Funcion para actualizar la puntuación
    public void UpdateScoreTextUI()
    {
        string scoreStr = string.Format("{0:0000000}", score); // Formateamos la puntuación
        scoreTextUI.text = scoreStr; // Actualizamos el texto de la puntuación
    }
}
