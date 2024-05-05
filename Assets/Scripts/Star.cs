using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public float speed; // Velocidad de la estrella

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position; // Posición actual de la estrella
        position = new Vector2(position.x, position.y + speed * Time.deltaTime); // Calculamos la nueva posición
        transform.position = position; // Actualizamos la posición de la estrella
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); // Esquina inferior izquierda de la pantalla
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); // Esquina superior derecha de la pantalla
        if (transform.position.y < min.y) // Si la estrella se sale de la pantalla
        {
            transform.position = new Vector2(Random.Range(min.x, max.x), max.y); // Posicionamos la estrella en una nueva posición
        }
    }
}
