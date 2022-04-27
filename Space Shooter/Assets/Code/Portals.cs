using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portals : MonoBehaviour
{
    [SerializeField] private Transform outLocation;

    public Transform GetDestination()
    {
        return outLocation;
        
    }
}

//portal code, anything with this script is recognized as a portal, but also needs the Portal tag