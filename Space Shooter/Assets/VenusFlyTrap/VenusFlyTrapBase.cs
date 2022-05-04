using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenusFlyTrapBase : MonoBehaviour
{
    //Public variables
    public float distanceToReach;
    public VenusFlyTrapMouth flytrap;
    public Animator animator;
    int changer;

    //Private Variables
    private float flyTrapX;

    //Control methdos
    private void Start()
    {
        float diffX = transform.position.x - flytrap.transform.position.x;
        float diffY = transform.position.y - flytrap.transform.position.y;
        float diffZ = transform.position.z - flytrap.transform.position.z;

        changer = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Ship>())
        {
            if (changer == 0)
            {
                animator.Play("flytrapUp");
                changer = 1;
                animator.SetInteger("attack", changer);
                print("Working for up");

                //Three times to make sure the head moves quickly.
                flytrap.catchPlayer();
                flytrap.catchPlayer();
                flytrap.catchPlayer();
            }

            
        }
    }

    private void Update()
    {
        if (flytrap.gameObject.transform.localPosition.y > distanceToReach)
        {
            if (changer == 1)
            {
                animator.Play("flytrapDown");
                changer = 2;
                animator.SetInteger("attack", -1);
                print("Working for down");
            }

            flytrap.catchPlayer(true);
            flytrap.catchPlayer(true);
            flytrap.catchPlayer(true);
        }

        if (flytrap.gameObject.transform.localPosition.y <= -0.738)
        {
            flytrap.rigidbod2d.velocity = flytrap.rigidbod2d.velocity.normalized * 0;

            while (flytrap.gameObject.transform.localPosition.y < -0.738)
                flytrap.gameObject.transform.localPosition = new Vector3(0.0f, flytrap.gameObject.transform.localPosition.y + 0.1f, flytrap.gameObject.transform.localPosition.z);

            if (changer == 2)
            {
                animator.Play("flytrapSit");
                changer = 0;
                animator.SetInteger("attack", changer);
                print("Working for stop");
            }
        }

    }

}
