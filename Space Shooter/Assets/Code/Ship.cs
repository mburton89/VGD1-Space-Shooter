using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    public Transform projectileSpawnPoint2;

    public float acceleration;
    public float maxSpeed;
    public int maxArmor;
    public float fireRate;
    public float projectileSpeed;

    [HideInInspector] public float currentSpeed;
    [HideInInspector] public int currentArmor;

    [HideInInspector] public bool canShoot;

    [HideInInspector] ParticleSystem thrustParticles;
    private void Awake()
    {
        currentArmor = maxArmor;
        canShoot = true;
        thrustParticles = GetComponentInChildren<ParticleSystem>();
    }

    private void FixedUpdate()
    {
        if (rigidbody2D.velocity.magnitude > maxSpeed)
        {
            rigidbody2D.velocity = rigidbody2D.velocity.normalized * maxSpeed;
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.GetComponent<ParticleSystem>())
        {
            TakeDamage(1);
        }
    }

    public void Thrust()
    {
        rigidbody2D.AddForce(transform.up * acceleration);
        if (thrustParticles != null)
        {
            thrustParticles.Emit(1);
        }
    }
    public void FireProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(transform.up * projectileSpeed);
        projectile.GetComponent<Projectile>().GetFired(gameObject);
        Destroy(projectile, 4);

        if (projectileSpawnPoint2 != null)
        {
            GameObject projectile2 = Instantiate(projectilePrefab, projectileSpawnPoint2.position, transform.rotation);
            projectile2.GetComponent<Rigidbody2D>().AddForce(transform.up * projectileSpeed);
            projectile2.GetComponent<Projectile>().GetFired(gameObject);
            Destroy(projectile2, 4);
        }

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
        currentArmor -= damageToGive;
        if (currentArmor <= 0)
        {
            Explode();
        }

        if (GetComponent<PlayerShip>())
        {
            HUD.Instance.DisplayPlayerHealth(currentArmor, maxArmor);
        }
    }
    public void Explode()
    {
        if (GetComponent<PlayerShip>())
        {
            GameManager.Instance.GameOver();
        }

        ScreenShakeManager.Instance.ShakeScreen();
        Instantiate(Resources.Load("Explosion"), transform.position, transform.rotation);
        Destroy(gameObject);

        //FindObjectOfType<EnemyShipSpawner>().CountEnemyShips();
    }
}
