using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBeltGenerator : MonoBehaviour
{
    public List<GameObject> asteroidPrefabs;
    public int numberOfAsteroidsToSpawn;
    public float distanceFromCenter;
    public float beltThickness;
    public float asteroidSize;
    public float asteroidRotateSpeed;

    public Transform spawnPoint;
    public Transform spawnPivot;

    void Start()
    {
        spawnPoint.position = new Vector3(0, distanceFromCenter, 0);

        for (int i = 0; i < numberOfAsteroidsToSpawn; i++)
        {
           
            float zRotation = Random.Range(0, 360);
            spawnPivot.eulerAngles = new Vector3(0, 0, zRotation);

            float randThickness = Random.Range(-beltThickness, beltThickness);
            Vector3 newSpawnPosition = new Vector3(0, distanceFromCenter + randThickness, Random.Range(-2.0f ,2.0f));

            int rand = Random.Range(0, asteroidPrefabs.Count);

            GameObject asteroid = Instantiate(asteroidPrefabs[rand], newSpawnPosition, transform.rotation, transform);
            asteroid.GetComponent<RotateZ>().rotateSpeed = Random.Range(-asteroidRotateSpeed, asteroidRotateSpeed);
            asteroid.transform.localScale = new Vector3(asteroidSize, asteroidSize, 1);
            asteroid.GetComponent<SpriteRenderer>().sortingOrder = (int)transform.localPosition.z;
        }
    }

}
