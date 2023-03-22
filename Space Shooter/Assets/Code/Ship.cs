using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
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

    [HideInInspector] ParticleSystem thrustParticles;

    public List<string> sentences;
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

    public void ShootSentence()
    {
        int rand = UnityEngine.Random.Range(0, sentences.Count);
        string sentenceToShoot = sentences[rand];
        StartCoroutine(ShootSentenceCo(sentenceToShoot));
    }

    private IEnumerator ShootSentenceCo(string sentence)
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
            GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);
            projectile.GetComponent<Rigidbody2D>().AddForce(transform.up * projectileSpeed);
            projectile.GetComponent<Projectile>().GetFired(gameObject);
            projectile.GetComponent<Projectile>().letter.SetText(character.ToString());
            projectile.transform.eulerAngles = Vector3.zero;
            Destroy(projectile, 4);
            yield return new WaitForSeconds(secondsBetweenLetters);
        }
    }
}
