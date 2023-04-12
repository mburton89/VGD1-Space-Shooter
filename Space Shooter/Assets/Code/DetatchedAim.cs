using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetatchedAim : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    public Rigidbody2D rb2d;

    private bool canShoot;
    private float fireRate;
    private float projectileSpeed;

    private Vector3 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        fireRate = GameObject.Find("PlayerShip").GetComponent<PlayerShip>().fireRate; // this allows you to edit the Fire Rate on PlayerShip
        projectileSpeed = GameObject.Find("PlayerShip").GetComponent<PlayerShip>().projectileSpeed;
    }

    // Update is called once per frame

    void Update()
    {
        FaceMouse();
        if (Input.GetMouseButtonDown(0))
        {
            FireAtMouse();
        }
    }
    
    void FaceMouse() // i have no idea why this doesn't work
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg -90);

        /*Debug.Log("mousePos: " + mousePos);
        Debug.Log("angleToFace: " + angleToFace);
        Debug.Log("eulerAngs: " + eulerAngs);//*/

    }
    private IEnumerator FireRateBuffer()
    {
        canShoot = false;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
    void FireAtMouse()
    {
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(transform.up *100.0f);
        projectile.GetComponent<Projectile>().GetFired(gameObject);
        Destroy(projectile, 4);
        StartCoroutine(FireRateBuffer());
    }
}
