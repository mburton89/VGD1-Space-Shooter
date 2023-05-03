using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CroissantProjectile : MonoBehaviour
{
   
    //damage applied
    public int damageToGive;
    [HideInInspector] public GameObject firingShip;

    //noise to play
    public AudioSource blipSound;
    
    //has the projectile been deflected?
    [HideInInspector] public bool isDeflecting;

    //can the projectile convert enemies? (this likely wont be used but i left it in anyways)
    public bool isConverting;
    [HideInInspector] public Transform target;


    private void Start()
    {
        //target player on spawn and play applied sound
        target = FindObjectOfType<PlayerShip>().transform;
        blipSound.pitch = Random.Range(.8f, 1.3f);
        blipSound.Play();
    }

    public void FlyTowardPlayer()
    {
        if (target == null) return;

        Vector2 directionToFace = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
        transform.up = directionToFace;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        //if (firingShip.GetComponent<EnemyShip>() && !firingShip.GetComponent<EnemyShip>().isConverted && collision.GetComponent<EnemyShip>()) return;

        if (isConverting && collision.GetComponent<EnemyShip>())
        {
            collision.GetComponent<EnemyShip>().TryConvert();
            Destroy(gameObject);
        }
        else if (collision.GetComponent<Ship>() && collision.gameObject != firingShip)
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
