using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : Ship
{
    public float turnSpeed;
    void Update()
    {
        //FollowMouse();
        HandleInput();
    }

    void HandleInput()
    {
        //new movement controls
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            Thrust();
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            controlRotation();
        }
        if (Input.GetMouseButtonDown(0))
        {
            FireProjectile();
        }
        /*//old movement
        if (Input.GetMouseButtonDown(1))
        {
            Thrust();
        }*/
    }
    void FollowMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        Vector2 directionToFace = new Vector2(
            mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = directionToFace;
    }
    void controlRotation()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) // counter-clockwise (left)
        {
            transform.Rotate(new Vector3 (0,0,turnSpeed));
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) // clockwise (right)
        {
            transform.Rotate(new Vector3(0, 0, -turnSpeed));
        }
    }
}
