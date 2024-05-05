using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    public GameObject StarGO; // Referencia al prefab de la estrella
    public int MaxStars; // Número máximo de estrellas

    // Arreglo de colores de las estrellas
    Color[] starColors = {
        new Color(0.5f, 0.5f, 1), // Azul
        new Color(0, 1f, 1f), // Verde
        new Color(1f, 1f, 0), // Amarillo
        new Color(1f, 0, 0), // Rojo
    };

    // Start is called before the first frame update
    void Start()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); // Esquina inferior izquierda de la pantalla
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); // Esquina superior derecha de la pantalla

        // Loop para crear las estrellas
        for (int i = 0; i < MaxStars; i++)
        {
            GameObject star = (GameObject)Instantiate(StarGO); // Creamos una nueva estrella
            star.GetComponent<SpriteRenderer>().color = starColors[i % starColors.Length]; // Asignamos un color a la estrella
            star.transform.position = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y)); // Posicionamos la estrella en una posición aleatoria
            star.GetComponent<Star>().speed = -(1f * Random.value + 0.5f); // Asignamos una velocidad aleatoria a la estrella
            star.transform.parent = transform; // Asignamos el objeto estrella como hijo del objeto StarGenerator
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
