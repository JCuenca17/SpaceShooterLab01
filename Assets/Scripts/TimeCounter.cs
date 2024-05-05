using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    Text timeUI; // Referencia al componente Text

    float startTime; // Tiempo de inicio
    float ellapsedTime; // El tiempo transcurrido
    bool startCounter; // Indica si se debe empezar a contar

    int minutes;
    int seconds;

    // Start is called before the first frame update
    void Start()
    {
        startCounter = false;
        timeUI = GetComponent<Text>(); // Obtenemos la referencia al componente Text
    }

    // Funcion para iniciar el contador de tiempo
    public void StartTimeCounter()
    {
        startTime = Time.time; // Guardamos el tiempo de inicio
        startCounter = true; // Indicamos que se debe empezar a contar
    }

    // Funcion para detener el contador de tiempo
    public void StopTimeCounter()
    {
        startCounter = false; // Indicamos que se debe parar de contar
    }

    // Update is called once per frame
    void Update()
    {
        if (startCounter) // Si se debe empezar a contar
        {
            ellapsedTime = Time.time - startTime; // Calculamos el tiempo transcurrido
            minutes = (int)ellapsedTime / 60; // Calculamos los minutos
            seconds = (int)ellapsedTime % 60; // Calculamos los segundos
            timeUI.text = string.Format("{0:00}:{1:00}", minutes, seconds); // Actualizamos el texto del contador de tiempo
        }
    }
}
