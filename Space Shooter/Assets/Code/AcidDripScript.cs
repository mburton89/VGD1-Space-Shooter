using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidDripScript : MonoBehaviour
{
    Transform target;
    public Rigidbody2D rigidbody2D;
    public float acceleration;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<Planet>().transform;
    }

    //if colliides it goes away

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerShip>())
        {
            collision.gameObject.GetComponent<PlayerShip>().TakeDamage(1);
            Destroy(gameObject);
        }

        else if (collision.gameObject.GetComponent<Planet>())
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
            fallToPlanet();
    }

    private void fallToPlanet()
    {
        Vector2 directionToFace = new Vector2(
            target.position.x - transform.position.x, target.position.y - transform.position.y);
        transform.up = directionToFace;
        rigidbody2D.AddForce(transform.up * acceleration);
    }

    
}
