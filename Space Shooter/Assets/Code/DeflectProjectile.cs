using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeflectProjectile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Projectile>())
        {
            collision.GetComponent<Rigidbody2D>().velocity = -collision.GetComponent<Rigidbody2D>().velocity * 2;
            collision.GetComponent<Projectile>().damageToGive *= 2;
            collision.GetComponent<Projectile>().firingShip = null;
        }
    }
}
