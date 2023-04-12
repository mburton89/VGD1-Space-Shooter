using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class PlayerShip : Ship
{
    public float turnSpeed;
    void Update()
    {
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
        /*if (Input.GetMouseButtonDown(0))
        {
            PlayerFireProjectile();
        }*/
        /*//old movement
        if (Input.GetMouseButtonDown(1))
        {
            Thrust();
        }*/
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
    private IEnumerator FireRateBuffer()
    {
        canShoot = false;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
    public void PlayerFireProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(transform.up * projectileSpeed);
        projectile.GetComponent<Projectile>().GetFired(gameObject);
        Destroy(projectile, 4);
        StartCoroutine(FireRateBuffer());
    }
}
