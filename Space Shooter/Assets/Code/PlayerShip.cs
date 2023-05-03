using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : Ship
{
    public float turnSpeed;
    [HideInInspector] public int activeWeaponIndex;
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            Thrust();
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            controlRotation();
        }
        //FollowMouse();
        HandleInput();
    }

    void HandleInput()
    {

        //if (Input.GetMouseButton(1))
        //{
        //    Thrust();
        //}

        if (!canUseSentenceAbility) return;

        if (Input.GetMouseButtonDown(0))
        {
            int activeWeaponIndex = WeaponSwitchManager.Instance.weaponIndex;

            if (activeWeaponIndex == 0)
            {
                ShootConvert();
            }
            else if (activeWeaponIndex == 1)
            {
                ShootShield();
            }
            else if (activeWeaponIndex == 2)
            {
                ShootDamage();
            }
            else if (activeWeaponIndex == 3)
            {
                ShootSpaceRage();
            }
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

    void controlRotation()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) // counter-clockwise (left)
        {
            transform.Rotate(new Vector3(0, 0, turnSpeed));
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) // clockwise (right)
        {
            transform.Rotate(new Vector3(0, 0, -turnSpeed));
        }
    }
}
