using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipSpawner : MonoBehaviour
{
    public List<EnemyShip> enemyShipPrefabs;
    public Transform spawnPoint;
    public Transform spawnPivot;

    [HideInInspector] public int currentWave = 1;
    [HideInInspector] public int startingNumberOfShips;

    public List<GameObject> wave2Prefabs;
    public List<GameObject> wave3Prefabs;
    public List<GameObject> wave4Prefabs;
    public List<GameObject> wave5Prefabs;
    public List<GameObject> wave6Prefabs;
    public List<GameObject> wave7Prefabs;
    public List<GameObject> wave8Prefabs;
    public List<GameObject> wave9Prefabs;
    public List<GameObject> wave10Prefabs;

    private void Awake()
    {
        startingNumberOfShips = FindObjectsOfType<EnemyShip>().Length;
    }

/*    private void Start()
    {
        InvokeRepeating("CountEnemyShips", 0, 3);
    }*/

    public void SpawnEnemyShips()
    {
        int enemyShipsToSpawn = startingNumberOfShips + currentWave;

        for (int i = 0; i < enemyShipsToSpawn; i++)
        {
            int rand = Random.Range(0, enemyShipPrefabs.Count);
            float zRotation = Random.Range(0, 360);

            spawnPivot.eulerAngles = new Vector3(0, 0, zRotation);
            Instantiate(enemyShipPrefabs[rand], spawnPoint.position, transform.rotation, null);
        }
    }

    public void CountEnemyShips()
    {
        StartCoroutine(CountEnemyShipsCo());
    }

    private IEnumerator CountEnemyShipsCo()
    {
        yield return new WaitForSeconds(3);
        int numberOfEnemyShips = FindObjectsOfType<EnemyShip>().Length;

        print(numberOfEnemyShips);

        if (numberOfEnemyShips == 0)
        {
            currentWave++;
            HUD.Instance.DisplayWave(currentWave);
            SpawnWave(currentWave);
        }
    }

    void SpinSpawnPosition()
    {
        int rand = Random.Range(0, enemyShipPrefabs.Count);
        float zRotation = Random.Range(0, 360);
        spawnPivot.eulerAngles = new Vector3(0, 0, zRotation);
    }

    void SpawnWave(int wave)
    {
        if (wave == 2)
        { 
            for (int i = 0; i < wave2Prefabs.Count; i++)
            {
                SpinSpawnPosition();
                Instantiate(wave2Prefabs[i], spawnPoint.position, transform.rotation, null);
            }
        }
        else if (wave == 3)
        {
            for (int i = 0; i < wave3Prefabs.Count; i++)
            {
                SpinSpawnPosition();
                Instantiate(wave3Prefabs[i], spawnPoint.position, transform.rotation, null);
            }
        }
        else if (wave == 4)
        {
            for (int i = 0; i < wave4Prefabs.Count; i++)
            {
                SpinSpawnPosition();
                Instantiate(wave4Prefabs[i], spawnPoint.position, transform.rotation, null);
            }
        }
        else if (wave == 5)
        {
            for (int i = 0; i < wave5Prefabs.Count; i++)
            {
                SpinSpawnPosition();
                Instantiate(wave5Prefabs[i], spawnPoint.position, transform.rotation, null);
            }
        }
        else if (wave == 6)
        {
            for (int i = 0; i < wave6Prefabs.Count; i++)
            {
                SpinSpawnPosition();
                Instantiate(wave6Prefabs[i], spawnPoint.position, transform.rotation, null);
            }
        }
        else if (wave == 7)
        {
            for (int i = 0; i < wave7Prefabs.Count; i++)
            {
                SpinSpawnPosition();
                Instantiate(wave7Prefabs[i], spawnPoint.position, transform.rotation, null);
            }
        }
        else if (wave == 8)
        {
            for (int i = 0; i < wave8Prefabs.Count; i++)
            {
                SpinSpawnPosition();
                Instantiate(wave8Prefabs[i], spawnPoint.position, transform.rotation, null);
            }
        }
        else if (wave == 9)
        {
            for (int i = 0; i < wave9Prefabs.Count; i++)
            {
                SpinSpawnPosition();
                Instantiate(wave9Prefabs[i], spawnPoint.position, transform.rotation, null);
            }
        }
        else if (wave == 10)
        {
            for (int i = 0; i < wave10Prefabs.Count; i++)
            {
                SpinSpawnPosition();
                Instantiate(wave10Prefabs[i], spawnPoint.position, transform.rotation, null);
            }
        }
    }
}
