using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeflectProjectile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Projectile>() && !collision.GetComponent<Projectile>().isDeflecting)
        {
            collision.GetComponent<Rigidbody2D>().velocity = -collision.GetComponent<Rigidbody2D>().velocity * 3;
            collision.GetComponent<Projectile>().isDeflecting = true;
            collision.GetComponent<Projectile>().damageToGive *= 3;
            collision.GetComponent<Projectile>().firingShip = null;
        }
    }
}
