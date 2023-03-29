using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : Ship
{ 
    void Update()
    {
        FollowMouse();
        HandleInput();
    }

    void HandleInput()
    {
        if (Input.GetMouseButton(1))
        {
            Thrust();
        }
        if (Input.GetMouseButtonDown(0))
        {
            //ShootSentence();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ShootConvert();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ShootShield();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ShootBackupBuddy();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ShootDamage();
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            ShootSpaceRage();
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            ShootCensorBeam();
        }
    }
    void FollowMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        Vector2 directionToFace = new Vector2(
            mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = directionToFace;
    }
}
