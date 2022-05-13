using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damageToGive;
    GameObject firingShip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (firingShip.GetComponent<EnemyShip>() && collision.GetComponent<EnemyShip>())
            return;

        if (collision.GetComponent<Ship>() && collision.gameObject != firingShip)
        {
            collision.GetComponent<Ship>().TakeDamage(damageToGive);
            Destroy(gameObject);
        }

        if (collision.GetComponent<Planet>() && firingShip.GetComponent<PlayerShip>())
        {
            collision.GetComponent<Planet>().TakeDamage(damageToGive);
            Destroy(gameObject);
        }
    }

    public void GetFired(GameObject firer)
    {
        firingShip = firer;
    }
}
