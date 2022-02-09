using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;

    public float acceleration;
    public float maxSpeed;
    public int maxArmor;
    public float fireRate;
    public float projectileSpeed;

    public float currentSpeed;
    public int currentArmor;

    private void FixedUpdate()
    {
        if (rigidbody2D.velocity.magnitude > maxSpeed)
        {
            rigidbody2D.velocity = rigidbody2D.velocity.normalized * maxSpeed;
        }
    }

    public void Thrust()
    {
        rigidbody2D.AddForce(transform.up * acceleration);
    }
    public void FireProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(transform.up * projectileSpeed);
        Destroy(projectile, 4);
    }
    public void TakeDamage()
    {

    }
    public void Explode()
    {

    }
}
