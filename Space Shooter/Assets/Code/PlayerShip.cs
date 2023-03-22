using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : Ship
{
    public int healValue;

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
            FireProjectile();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HealthPack"))
        {
            currentArmor += healValue;
            HUD.Instance.DisplayPlayerHealth(currentArmor, maxArmor);

            if (currentArmor > maxArmor)
            {
                currentArmor = maxArmor;
            }
        }
    }
}
