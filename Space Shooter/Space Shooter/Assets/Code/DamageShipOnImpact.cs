using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageShipOnImpact : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyShip>())
        {
            collision.GetComponent<EnemyShip>().TakeDamage(1000);
        }
        if (collision.GetComponent<Projectile>())
        {
            Instantiate(Resources.Load("Lil Explosion"), transform.position, transform.rotation);
            Destroy(collision.gameObject);
        }
    }
}
