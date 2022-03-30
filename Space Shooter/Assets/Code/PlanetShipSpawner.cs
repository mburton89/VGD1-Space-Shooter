using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetShipSpawner : MonoBehaviour
{
    public List<EnemyShip> enemyShipPrefabs;
    public Transform spawnPoint;

    public void SpawnEnemyShip()
    { 
        int rand = Random.Range(0, enemyShipPrefabs.Count);
        Instantiate(enemyShipPrefabs[rand], spawnPoint.position, transform.rotation, null);
    }
}
