using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenusFlyTrapMouth : MonoBehaviour
{
    //Public variables
    //Currently there is no max speed to how fast the head/mouth can move.
    //        This may be changed later.
    public Rigidbody2D rigidbod2d;
    public float speed;
    public int damage;
    public Vector3 savedPosition;

    //Control methods
    private void Awake()
    {
        savedPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Ship>())
        {
            collision.GetComponent<Ship>().TakeDamage(damage);
        }
    }

    //Object methdod(s)

    //This may seem a bit backwards but false is used to move the head forward.
    //True is used to move the head back. The default moves the head forward.
    public void catchPlayer(bool retreat = false)
    {

        if (retreat)
            rigidbod2d.AddForce(transform.up * (speed * -1));
        else
            rigidbod2d.AddForce(transform.up * speed);

    }

}
