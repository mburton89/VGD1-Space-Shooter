using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanTeleport : MonoBehaviour
{
    private GameObject currentTP;

    private bool canTP = true;

    public float tpCooldown;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Portal") && canTP == true)
        {
            currentTP = collision.gameObject;
            transform.position = currentTP.GetComponent<Portals>().GetDestination().position;
            FindObjectOfType<AudioManager>().Play("portal");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Portal"))
        {
            if (collision.gameObject == currentTP)
            {
                currentTP = null;
                StartCoroutine(TPBuffer());
            }
        }
    }


    private IEnumerator TPBuffer()
    {
        canTP = false;
        yield return new WaitForSeconds(tpCooldown);
        canTP = true;
    }
}
//Actual teleporting code, anything given this script can teleport. This is so things like the moon or other unwanted objects don't teleport