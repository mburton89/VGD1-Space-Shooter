using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    GameObject PlayerShip;
    // Start is called before the first frame update
    void Start()
    {
        PlayerShip = GameObject.Find("PlayerShip");
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfVisible();
    }
    void CheckIfVisible()
    {

    }
}
