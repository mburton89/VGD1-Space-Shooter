using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Rigidbody2D Rigidbody2D;
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;

    public float acceleration;
    public float maxSpeed;
    public int maxArmor;
    public float fireRate;
    public float projectileSpeed;

    [HideInInspector] public float currentSpeed;
    [HideInInspector] public int currentArmor;

    [HideInInspector] public bool canShoot;
    [HideInInspector] public bool canDamagePlayer;

    [HideInInspector] ParticleSystem thrustParticles;
    [HideInInspector] GameObject playerShip;
    [HideInInspector] Transform playerTransform;
    private void Awake()
    {
        currentArmor = maxArmor;
        canShoot = true;
        thrustParticles = GetComponentInChildren<ParticleSystem>();
    }

    private void FixedUpdate()
    {
        if (GetComponent<Rigidbody2D>().velocity.magnitude > maxSpeed)
        {
            GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity.normalized * maxSpeed;
        }
    }

    public void Thrust()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * acceleration);
        thrustParticles.Emit(1);
    }
    public void FireProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(transform.up * projectileSpeed);
        projectile.GetComponent<Projectile>().GetFired(gameObject);
        Destroy(projectile, 4);
        StartCoroutine(FireRateBuffer());
    }

    private IEnumerator FireRateBuffer()
    {
        canShoot = false;
        yield return new WaitForSeconds(fireRate); 
        canShoot = true;
    }

    public void TakeDamage(int damageToGive)
    {
        //TODO: play getHitSound
        playerShip = GameObject.Find("PlayerShip");
        Transform playerTransform = playerShip.GetComponent<Transform>();
        if(playerTransform.position.z == this.transform.position.z)
        {
            currentArmor -= damageToGive;
        }// checks if the enemies should be able to hit player on Z axis
        
        if (currentArmor <= 0)
        {
            Explode();
        }

        if (GetComponent<PlayerShip>())
        {
            HUD.Instance.DisplayHealth(currentArmor, maxArmor);
        }
    }
    public void Explode()
    {
        ScreenShakeManager.Instance.ShakeScreen();
        Instantiate(Resources.Load("Explosion"), transform.position, transform.rotation);
        Destroy(gameObject);

        FindObjectOfType<EnemyShipSpawner>().CountEnemyShips();
    }
}
