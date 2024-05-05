using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public float speed; // Velocidad del planeta
    public bool isMoving; // Indica si el planeta se está moviendo

    Vector2 min; // Esquina inferior izquierda de la pantalla
    Vector2 max; // Esquina superior derecha de la pantalla

    void Awake()
    {
        isMoving = false; // Inicializamos la variable isMoving a false
        min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); // Obtenemos la esquina inferior izquierda de la pantalla
        max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); // Obtenemos la esquina superior derecha de la pantalla

        max.y = max.y + GetComponent<SpriteRenderer>().sprite.bounds.extents.y; // Ajustamos la posición de la esquina superior derecha
        min.y = min.y - GetComponent<SpriteRenderer>().sprite.bounds.extents.y; // Ajustamos la posición de la esquina inferior izquierda
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving) // Si el planeta no se está moviendo
            return; // Salimos de la función

        Vector2 position = transform.position; // Posición actual del planeta
        position = new Vector2(position.x, position.y + speed * Time.deltaTime); // Calculamos la nueva posición
        transform.position = position; // Actualizamos la posición del planeta
        if (transform.position.y < min.y) // Si el planeta se sale de la pantalla 
        {
            isMoving = false; // Indicamos que el planeta no se está moviendo
        }

    }

    // Función para reiniciar la posición del planeta
    public void ResetPosition()
    {
        transform.position = new Vector2(Random.Range(min.x, max.x), max.y); // Posicionamos el planeta en una posición aleatoria en la parte superior de la pantalla
    }
}
