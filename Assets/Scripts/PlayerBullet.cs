using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position; // Posición actual de la bala
        position = new Vector2(position.x, position.y + speed * Time.deltaTime); // Calculamos la nueva posición
        transform.position = position; // Actualizamos la posición de la bala
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); // Esquina superior derecha de la pantalla
        if (transform.position.y > max.y) // Si la bala se sale de la pantalla
        {
            Destroy(gameObject); // Destruimos la bala
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "EnemyShipTag") // Si la bala colisiona con un enemigo
        {
            Destroy(gameObject); // Destruimos la bala
        }
    }
}
