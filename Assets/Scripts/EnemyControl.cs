using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    GameObject scoreUITextGO; // Referencia al objeto del texto de la puntuación
    public GameObject ExplosionGO; // Referencia al prefab de la explosión

    float speed; // Velocidad del enemigo

    // Start is called before the first frame update
    void Start()
    {
        speed = 2f; // Asignamos la velocidad del enemigo
        scoreUITextGO = GameObject.FindGameObjectWithTag("ScoreTextTag"); // Buscamos el objeto del texto de la puntuación
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position; // Posición actual del enemigo
        position = new Vector2(position.x, position.y - speed * Time.deltaTime); // Calculamos la nueva posición
        transform.position = position; // Actualizamos la posición del enemigo
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); // Esquina inferior izquierda de la pantalla
        if (transform.position.y < min.y) // Si el enemigo se sale de la pantalla
        {
            Destroy(gameObject); // Destruimos el enemigo
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Si el enemigo colisiona con la nave del jugador o con una bala del jugador
        if ((col.tag == "PlayerShipTag") || (col.tag == "PlayerBulletTag"))
        {
            PlayExplosion(); // Llamamos a la función para instanciar la explosión
            scoreUITextGO.GetComponent<GameScore>().Score += 100; // Aumentamos la puntuación en 100 puntos
            Destroy(gameObject); // Destruimos el enemigo
        }
    }

    // Función para instanciar la explosión
    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionGO); // Creamos una nueva explosión
        explosion.transform.position = transform.position; // Posicionamos la explosión en la posición del enemigo
    }
}
