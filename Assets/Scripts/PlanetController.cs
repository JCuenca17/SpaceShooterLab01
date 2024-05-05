using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    public GameObject[] Planets; // Referencia a los planetas

    Queue<GameObject> availablePlanets = new Queue<GameObject>(); // Cola de planetas

    // Start is called before the first frame update
    void Start()
    {
        availablePlanets.Enqueue(Planets[0]); // Añadimos el primer planeta a la cola
        availablePlanets.Enqueue(Planets[1]); // Añadimos el segundo planeta a la cola
        availablePlanets.Enqueue(Planets[2]); // Añadimos el tercer planeta a la cola

        InvokeRepeating("MovePlanetDown", 0, 20f); // Llamamos a la función MovePlanetDown cada 20 segundos
    }

    // Update is called once per frame
    void Update()
    {

    }

    void MovePlanetDown()
    {
        EnqueuePlanets(); // Añadimos los planetas a la cola
        // Si no hay planetas disponibles en la cola
        if (availablePlanets.Count == 0)
        {
            return; // Salimos de la función
        }
        GameObject aPlanet = availablePlanets.Dequeue(); // Obtenemos el primer planeta de la cola
        aPlanet.GetComponent<Planet>().isMoving = true; // Indicamos que el planeta se está moviendo
    }

    void EnqueuePlanets()
    {
        foreach (GameObject aPlanet in Planets) // Para cada planeta en la lista de planetas
        {
            if ((aPlanet.transform.position.y < 0) && (!aPlanet.GetComponent<Planet>().isMoving)) // Si el planeta está en la parte inferior de la pantalla y no se está moviendo
            {
                aPlanet.GetComponent<Planet>().ResetPosition(); // Reiniciamos la posición del planeta
                availablePlanets.Enqueue(aPlanet); // Añadimos el planeta a la cola de planetas
            }
        }
    }
}
