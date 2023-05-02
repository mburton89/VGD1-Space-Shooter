using UnityEngine;
using UnityEngine.UI;

public class TiltButton : MonoBehaviour
{
    public float tiltAngle = 5f;     // The angle to tilt the button
    public float tiltSpeed = 2f;     // The speed at which to tilt the button

    private float currentAngle = 0f; // The current angle of the button

    private void Update()
    {
        // Calculate the new angle based on the current angle and the tilt speed
        currentAngle += tiltSpeed * Time.deltaTime;

        // Wrap the angle around if it goes over 360 degrees
        if (currentAngle > 360f)
        {
            currentAngle -= 360f;
        }

        // Calculate the tilt amount based on the current angle
        float tiltAmount = Mathf.Sin(Mathf.Deg2Rad * currentAngle) * tiltAngle;

        // Apply the tilt to the button's rotation
        transform.rotation = Quaternion.Euler(0f, 0f, tiltAmount);
    }
}
