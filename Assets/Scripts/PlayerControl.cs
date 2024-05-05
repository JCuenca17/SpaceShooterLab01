using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject GameManagerGO; // Referencia al objeto del GameManager

    public GameObject PlayerBulletGO; // Referencia al prefab de la bala
    public GameObject bulletPosition01;
    public GameObject bulletPosition02;
    public GameObject ExplosionGO; // Referencia al prefab de la explosión

    // Referenciaa las vidas
    public Text LivesUIText;

    const int MaxLives = 3; // Número máximo de vidas
    int lives; // Número de 

    public void Init()
    {
        lives = MaxLives;
        LivesUIText.text = lives.ToString(); // Actualizamos el texto de las vidas
        transform.position = new Vector2(0, 0); // Posicionamos al jugador en el centro de la pantalla
        gameObject.SetActive(true); // Activamos la nave del jugador
    }

    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) // Si se presiona la tecla espacio
        {
            GetComponent<AudioSource>().Play(); // Reproducimos el sonido de la bala

            GameObject bullet01 = (GameObject)Instantiate(PlayerBulletGO); // Creamos una nueva bala
            bullet01.transform.position = bulletPosition01.transform.position; // Posicionamos la bala en la posición del jugador

            GameObject bullet02 = (GameObject)Instantiate(PlayerBulletGO); // Creamos una nueva bala
            bullet02.transform.position = bulletPosition02.transform.position; // Posicionamos la bala en la posición del jugador
        }

        float x = Input.GetAxisRaw("Horizontal"); // -1, 0, 1 (Izquierda, Derecha)
        float y = Input.GetAxisRaw("Vertical"); // -1, 0, 1 (Abajo, Arriba)

        Vector2 direction = new Vector2(x, y).normalized;
        Move(direction);
    }

    void Move(Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); // Esquina inferior izquierda de la pantalla
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); // Esquina superior derecha de la pantalla

        max.x = max.x - 0.225f; // Restamos el ancho del jugador
        min.x = min.x + 0.225f; // Sumamos el ancho del jugador

        max.y = max.y - 0.285f; // Restamos el alto del jugador
        min.y = min.y + 0.285f; // Sumamos el alto del jugador

        Vector2 pos = transform.position; // Posición actual del jugador

        pos += direction * speed * Time.deltaTime; //Calculamos la nueva posición

        // Hacemos que la posición no se salga de la pantalla
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos; // Actualizamos la posición del jugador
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Detectamos la colisión del jugador con un enemigo o una bala enemiga
        if ((col.tag == "EnemyShipTag") || (col.tag == "EnemyBulletTag"))
        {

            PlayExplosion(); // Llamamos a la función para crear una explosión 
            lives--; // Restamos una vida
            LivesUIText.text = lives.ToString(); // Actualizamos el texto de las vidas
            if (lives == 0) // Si las vidas llegan a 0
            {
                GameManagerGO.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOver); // Cambiamos el estado del juego a GameOver
                gameObject.SetActive(false); // Desactivamos la nave del jugador
            }

        }
    }

    // Función para crear una explosión
    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionGO); // Creamos una explosión
        explosion.transform.position = transform.position; // Posicionamos la explosión en la posición del jugador
    }
}
