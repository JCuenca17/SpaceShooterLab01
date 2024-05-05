using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyGO; // Referencia al prefab del enemigo
    float maxSpawnRateInSeconds = 5f; // Tiempo máximo entre la aparición de enemigos

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemy()
    {
        // Esquina inferior izquierda de la pantalla
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        // Esquina superior derecha de la pantalla
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // Creamos un enemigo
        GameObject anEnemy = (GameObject)Instantiate(EnemyGO);
        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        // Llamamos a la función SpawnEnemy() cada 2 segundos
        ScheduleNextEnemySpawn();
    }

    void ScheduleNextEnemySpawn()
    {
        float spawnInSeconds;

        if (maxSpawnRateInSeconds > 1f)
        {
            // Un número aleatorio entre 1 y el tiempo máximo de aparición
            spawnInSeconds = Random.Range(1f, maxSpawnRateInSeconds);
        }
        else
            spawnInSeconds = 1f;

        Invoke("SpawnEnemy", spawnInSeconds);
    }

    // Aumentamos la dificultad del juego
    void IncreaseSpawnRate()
    {
        if (maxSpawnRateInSeconds > 1f) // Si el tiempo máximo de aparición es mayor a 1 segundo
            maxSpawnRateInSeconds--; // Reducimos el tiempo máximo de aparición
        if (maxSpawnRateInSeconds == 1f) // Si el tiempo máximo de aparición es igual a 1 segundo
            CancelInvoke("IncreaseSpawnRate"); // Cancelamos la invocación de la función IncreaseSpawnRate()
    }

    // Funcion para iniciar la generación de enemigos
    public void ScheduleEnemySpawner()
    {
        // Reseteamos el tiempo máximo de aparición
        maxSpawnRateInSeconds = 5f;

        Invoke("SpawnEnemy", maxSpawnRateInSeconds);

        // Aumentamos la dificultad del juego cada 30 segundos
        InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
    }

    // Función para detener la generación de enemigos
    public void UnscheduleEnemySpawner()
    {
        CancelInvoke("SpawnEnemy");
        CancelInvoke("IncreaseSpawnRate");
    }
}
