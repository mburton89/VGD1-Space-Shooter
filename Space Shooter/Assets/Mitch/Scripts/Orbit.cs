using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Orbit : MonoBehaviour
{
    public float orbitSpeed = 10f;
    public float startAngle = 0f;
    public float distance = 100f;
    public GameObject centerPoint;
    public Image image;

    private float angle;

    private void Start()
    {
        angle = startAngle + Mathf.Atan2(transform.position.y - centerPoint.transform.position.y, transform.position.x - centerPoint.transform.position.x);
    }

    private void Update()
    {
        angle += orbitSpeed * Time.deltaTime;
        float x = Mathf.Cos(angle) * distance;
        float y = Mathf.Sin(angle) * distance;
        transform.position = new Vector3(x, y, transform.position.z) + centerPoint.transform.position;
    }
}
