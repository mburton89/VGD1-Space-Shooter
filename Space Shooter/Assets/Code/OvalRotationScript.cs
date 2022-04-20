using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvalRotationScript : MonoBehaviour
{
    float alpha = 0f;
    public float RotSpeed;
    float rotation = 0f;

    // Update is called once per frame
    void Update()
    {
        rotateWiredly();
    }

    public void rotateWiredly()
    {
        //2ways
        //make 5 points to touch
        //oval pattern and rotatting**

        transform.position = new Vector2(0f + (17f * Mathf.Sin(Mathf.Deg2Rad * alpha)), 15f + (25f * Mathf.Cos(Mathf.Deg2Rad * alpha)));
        alpha += RotSpeed;//can be used as speed
    }
}
