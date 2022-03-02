using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipSpawner : MonoBehaviour
{
    public GameObject enemyShip1;
    public GameObject enemyShip2;
    public Transform spawnPoint1;
    public Transform spawnPoint2;

    public void SpawnEnemyShips()
    {
        Instantiate(enemyShip1, spawnPoint1.position, transform.rotation, null);
        Instantiate(enemyShip2, spawnPoint2.position, transform.rotation, null);
    }

    public void CountEnemyShips()
    {
        int numberOfEnemyShips = FindObjectsOfType<EnemyShip>().Length;

        print(numberOfEnemyShips);

        if (numberOfEnemyShips == 1)
        {
            SpawnEnemyShips();
        }
    }
}
