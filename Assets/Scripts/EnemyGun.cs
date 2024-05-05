using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject EnemyBulletGO; // Referencia al prefab de la bala del enemigo
    // Start is called before the first frame update
    void Start()
    {
        // fuego de la bala del enemigo cada 1 segundo
        Invoke("FireEnemyBullet", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Función para disparar una bala
    void FireEnemyBullet()
    {
        GameObject playerShip = GameObject.Find("PlayerGO"); // Buscamos al jugador
        if (playerShip != null) // Si el jugador no esta muerto
        {
            GameObject bullet = (GameObject)Instantiate(EnemyBulletGO); // Creamos una nueva bala
            bullet.transform.position = transform.position; // Posicionamos la bala en la posición del enemigo

            Vector2 direction = playerShip.transform.position - bullet.transform.position; // Dirección de la bala
            bullet.GetComponent<EnemyBullet>().SetDirection(direction); // Asignamos la dirección a la bala
        }
    }
}
