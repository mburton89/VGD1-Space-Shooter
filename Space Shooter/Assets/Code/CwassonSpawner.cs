using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CwassonSpawner : MonoBehaviour
{
    public GameObject cwassonProjectile;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCo());
    }


    private IEnumerator SpawnCo()
    {
        Instantiate(cwassonProjectile, transform.position, transform.rotation, null);
        yield return new WaitForSeconds(3);
        StartCoroutine(SpawnCo());

    }
}
