using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateZ : MonoBehaviour
{
    [SerializeField] float rotateSpeed;
    Vector3 rotation;

    private void Start()
    {
        rotation = new Vector3(0, 0, 1);
    }

    void Update()
    {
        transform.Rotate(rotation * rotateSpeed * Time.deltaTime);
    }
}
