using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 30f; // Speed of rotation in degrees per second

    private void Update()
    {
        // Rotate the object around its z-axis
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}