using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public GameObject convertProjectilePrefab;
    public GameObject damageProjectilePrefab;
    public Transform projectileSpawnPoint;

    public GameObject shieldPrefab;

    public float acceleration;
    public float maxSpeed;
    public int maxArmor;
    public float fireRate;
    public float projectileSpeed;

    [HideInInspector] public float currentSpeed;
    [HideInInspector] public int currentArmor;

    [HideInInspector] public bool canShoot;

    [HideInInspector] ParticleSystem thrustParticles;

    public List<string> goodSentences;
    public List<string> badSentences;
    public float secondsBetweenLetters;

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

    public void Thrust()
    {
        rigidbody2D.AddForce(transform.up * acceleration);
        thrustParticles.Emit(1);
    }
    public void FireProjectile()
    {
        GameObject projectile = Instantiate(damageProjectilePrefab, projectileSpawnPoint.position, transform.rotation);
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
        currentArmor -= damageToGive;
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

    public void ShootSentence(bool isGoodGuy)
    {
        int rand = 0;
        string sentenceToShoot = "";

        if (isGoodGuy)
        {
            rand = UnityEngine.Random.Range(0, goodSentences.Count);
            sentenceToShoot = goodSentences[rand];
        }
        else
        {
            rand = UnityEngine.Random.Range(0, badSentences.Count);
            sentenceToShoot = badSentences[rand];
        }

        StartCoroutine(ShootSentenceCo(sentenceToShoot, isGoodGuy));
    }

    private IEnumerator ShootSentenceCo(string sentence, bool isGoodGuy)
    {
        string newSentence = sentence;
        print(transform.rotation.z);
        if (transform.rotation.z < 0)
        {
            char[] stringArray = newSentence.ToCharArray();
            Array.Reverse(stringArray);
            newSentence = new string(stringArray);
        }

        foreach (char character in newSentence)
        {
            GameObject projectile;

            if (isGoodGuy)
            {
                projectile = Instantiate(convertProjectilePrefab, projectileSpawnPoint.position, transform.rotation);
            }
            else
            {
                projectile = Instantiate(damageProjectilePrefab, projectileSpawnPoint.position, transform.rotation);
            }

            projectile.GetComponent<Rigidbody2D>().AddForce(transform.up * projectileSpeed);
            projectile.GetComponent<Projectile>().GetFired(gameObject);
            projectile.GetComponent<Projectile>().letter.SetText(character.ToString());
            projectile.transform.eulerAngles = Vector3.zero;
            Destroy(projectile, 4);
            yield return new WaitForSeconds(secondsBetweenLetters);
        }
    }

    public void ShootConvert() //Good Guy 1
    {
        ShootSentence(true);
    }

    public void ShootShield() //Good Guy 2
    {
        GameObject shield = Instantiate(shieldPrefab, transform.position, transform.rotation, null);
        shield.GetComponent<CircleShield>().Init("Not today, Honey - Not today :)", true);
        shield.GetComponent<FollowTarget>().target = transform;
    }

    public void ShootBackupBuddy() //Good Guy 3
    {

    }

    public void ShootDamage()  // Bad Guy 1
    {
        ShootSentence(false);
    }

    public void ShootSpaceRage() // Bad Guy 2
    {

    }

    public void ShootCensorBeam() // Bad Guy 3
    {

    }
}
