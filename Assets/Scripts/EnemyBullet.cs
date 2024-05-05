using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float speed; // Velocidad de la bala
    Vector2 _direction; // Dirección de la bala
    bool isReady; // Bandera para saber si la bala está lista para ser lanzada

    void Awake()
    {
        speed = 5f; // Asignamos la velocidad de la bala
        isReady = false; // La bala no está lista para ser lanzada
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Función para inicializar la dirección de la bala
    public void SetDirection(Vector2 direction)
    {
        _direction = direction.normalized; // Obtenemos la dirección normalizada
        isReady = true; // La bala está lista para ser lanzada
    }

    // Update is called once per frame
    void Update()
    {
        if (isReady)
        {
            Vector2 position = transform.position; // Posición actual de la bala
            position += _direction * speed * Time.deltaTime; // Calculamos la nueva posición
            transform.position = position; // Actualizamos la posición de la bala
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); // Esquina inferior izquierda de la pantalla
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); // Esquina superior derecha de la pantalla
            if (transform.position.x < min.x || transform.position.x > max.x || transform.position.y < min.y || transform.position.y > max.y) // Si la bala se sale de la pantalla
            {
                Destroy(gameObject); // Destruimos la bala
            }
        }
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "PlayerShipTag") // Si la bala colisiona con la nave del jugador
        {
            Destroy(gameObject); // Destruimos la bala
        }
    }
}
