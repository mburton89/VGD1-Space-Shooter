using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetatchedAim : MonoBehaviour
{
    void Update()
    {
        FaceMouse();
    }
 
    void FaceMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg -90);
    }
}
