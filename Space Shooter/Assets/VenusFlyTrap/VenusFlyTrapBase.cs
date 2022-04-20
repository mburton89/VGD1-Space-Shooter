using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenusFlyTrapBase : MonoBehaviour
{
    //Public variables
    public float distanceToReach;
    public VenusFlyTrapMouth flytrap;

    //Control methdos
    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Ship>())
        {
            //Three times to make sure the head moves quickly.
            flytrap.catchPlayer();
            flytrap.catchPlayer();
            flytrap.catchPlayer();
        }
    }

    private void Update()
    {

        if (flytrap.gameObject.transform.localPosition.y > distanceToReach)
        {
            flytrap.catchPlayer(true);
        }

        if (flytrap.gameObject.transform.localPosition.y <= 0)
        {
            flytrap.rigidbod2d.velocity = flytrap.rigidbod2d.velocity.normalized * 0;

            while (flytrap.gameObject.transform.localPosition.y < 0.1)
                flytrap.gameObject.transform.localPosition = new Vector3(flytrap.gameObject.transform.localPosition.x, flytrap.gameObject.transform.localPosition.y + 0.1f, flytrap.gameObject.transform.localPosition.z);
        }

    }

}
