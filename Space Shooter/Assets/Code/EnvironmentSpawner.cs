using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentSpawner : MonoBehaviour
{
    public List<GameObject> environmentAssets;
    public int maxX;
    public int maxY;
    public int maxZ;
    public int minZ;

    void Start()
    {
        for (int i = 0; i < environmentAssets.Count; i++)
        {
            float randX = Random.Range(-maxX, maxX);
            float randY = Random.Range(-maxY, maxY);
            float randZ = Random.Range(minZ, maxZ);
            Vector3 spawnPosition = new Vector3(randX, randY, randZ);
            GameObject newGameObject = Instantiate(environmentAssets[i], spawnPosition, transform.rotation, transform);
            newGameObject.GetComponent<RotateZ>().rotateSpeed = Random.Range(-15f, 15f);
        }
    }
}
