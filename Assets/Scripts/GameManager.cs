using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Referencia a los objetos del juego
    public GameObject playButton;
    public GameObject playerShip;
    public GameObject enemySpawner; // Referencia al objeto del enemigo
    public GameObject GameOverGO; // Referencia a la imagen de Game Over
    public GameObject scoreUITextGO; // Referencia al objeto del texto de la puntuación
    public GameObject TimeCounterGO; // Referencia al objeto del contador de tiempo

    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver
    }

    GameManagerState GMState;

    // Start is called before the first frame update
    void Start()
    {
        GMState = GameManagerState.Opening;
    }

    // Funcion para actualizar el estado del juego
    void UpdateGameManagerState()
    {
        switch (GMState)
        {
            case GameManagerState.Opening:
                // Ocultamos Game Over
                GameOverGO.SetActive(false);
                // Cambiamos el estado del boton de inicio a activo
                playButton.SetActive(true);
                break;
            case GameManagerState.Gameplay:
                // Reseteamos la puntuación
                scoreUITextGO.GetComponent<GameScore>().Score = 0;
                // Ocultamos el botón de inicio
                playButton.SetActive(false);
                // hacemos que la nave del jugador esté activa
                playerShip.GetComponent<PlayerControl>().Init();
                // Iniciamos la generación de enemigos
                enemySpawner.GetComponent<EnemySpawner>().ScheduleEnemySpawner();
                // Iniciamos el contador de tiempo
                TimeCounterGO.GetComponent<TimeCounter>().StartTimeCounter();
                break;
            case GameManagerState.GameOver:
                // Paramos el contador de tiempo
                TimeCounterGO.GetComponent<TimeCounter>().StopTimeCounter();
                // Paramos la generación de enemigos
                enemySpawner.GetComponent<EnemySpawner>().UnscheduleEnemySpawner();
                // Mostramos el Game Over
                GameOverGO.SetActive(true); 
                Invoke("ChangeToOpeningState", 8f); // Cambiamos el estado del juego a Opening después de 8 segundos
                break;
        }
    }

    // Funcion para cambiar el estado del juego
    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }

    // Funcion para iniciar el juego
    public void StartGamePlay()
    {
        GMState = GameManagerState.Gameplay;
        UpdateGameManagerState();
    }

    // Funcion para cambiar el estado del juego a Opening
    public void ChangeToOpeningState()
    {
        SetGameManagerState(GameManagerState.Opening);
    }
}
