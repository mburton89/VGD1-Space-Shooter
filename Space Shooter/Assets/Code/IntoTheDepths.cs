using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntoTheDepths : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.G))
        {
            TravelDeeper();
        }
        if (Input.GetKey(KeyCode.T))
        {
            TravelUp();
        }
    }

    public void TravelDeeper()
    {
        GameObject playerShip = GameObject.Find("PlayerShip");
        Transform playerTransform = playerShip.GetComponent<Transform>();
        playerTransform.position += new Vector3(0, 0, 0.3f);
    }
    public void TravelUp()
    {
        GameObject playerShip = GameObject.Find("PlayerShip");
        Transform playerTransform = playerShip.GetComponent<Transform>();
        playerTransform.position += new Vector3(0, 0, -0.3f);
    }
}
