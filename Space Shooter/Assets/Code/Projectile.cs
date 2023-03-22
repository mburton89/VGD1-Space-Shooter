using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Projectile : MonoBehaviour
{
    public int damageToGive;
    GameObject firingShip;
    public TextMeshProUGUI letter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Ship>() && collision.gameObject != firingShip)
        {
            collision.GetComponent<Ship>().TakeDamage(damageToGive);
            Destroy(gameObject);
        }
    }

    public void GetFired(GameObject firer)
    {
        firingShip = firer;
    }
}
