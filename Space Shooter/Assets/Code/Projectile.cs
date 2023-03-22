using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Projectile : MonoBehaviour
{
    public int damageToGive;
    GameObject firingShip;
    public TextMeshProUGUI letter;
    public AudioSource blipSound;

    private void Start()
    {
        blipSound.pitch = Random.Range(.8f, 1.2f);
        blipSound.Play();
    }

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
