using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CircleLetter: MonoBehaviour
{
    public TextMeshProUGUI letter;
    public float rotationSpeed;
    public float secondsToLive;

    void Start()
    {
        Destroy(gameObject, secondsToLive);
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1) * rotationSpeed * Time.deltaTime);

        print(transform.rotation.eulerAngles.z);
    }
}
