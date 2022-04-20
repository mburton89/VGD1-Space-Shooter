using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonDripScript : MonoBehaviour
{

    public GameObject dripPrefab;

    [HideInInspector] public int hold = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hold == 0)
        {
            StartCoroutine(fullOrbit());
            hold = 1;
        }
    }

    private void makeDrip()
    {
            GameObject newDrip = Instantiate(dripPrefab, transform.position, transform.rotation);
        hold = 0;
    }

    IEnumerator fullOrbit()
    {     
        yield return new WaitForSeconds(6);
        makeDrip();
    }
}
