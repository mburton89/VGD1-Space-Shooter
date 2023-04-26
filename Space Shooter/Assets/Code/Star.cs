using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    GameObject PlayerShip;
    Transform cameraPosition;
    // Start is called before the first frame update
    void Start()
    {
        PlayerShip = GameObject.Find("PlayerShip");
        cameraPosition = PlayerShip.GetComponent<Transform>();
        Debug.Log(cameraPosition.position);
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfVisible();
    }
    void CheckIfVisible()
    {
        //Debug.Log("PlayerShip Position:" + cameraPosition.position);
    }
}
