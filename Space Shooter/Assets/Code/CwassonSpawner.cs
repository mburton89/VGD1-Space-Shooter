using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CwassonSpawner : MonoBehaviour
{
    public GameObject cwassonProjectile;
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCo());
    }


    private IEnumerator SpawnCo()
    {
        Instantiate(cwassonProjectile, spawnPoint.position, transform.rotation, null);
        yield return new WaitForSeconds(3);
        StartCoroutine(SpawnCo());

    }
}
