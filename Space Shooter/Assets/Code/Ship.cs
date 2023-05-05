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
    public GameObject badShieldPrefab;

    public float acceleration;
    public float maxSpeed;
    public int maxArmor;
    public float fireRate;
    public float projectileSpeed;

    [HideInInspector] public float currentSpeed;
    [HideInInspector] public int currentArmor;
    [HideInInspector] public bool canShoot;

    //[HideInInspector] ParticleSystem thrustParticles;
    public List<ParticleSystem> thrustParticleSystems;

    public List<string> goodSentences;
    public List<string> badSentences;
    public string introBark;
    public float secondsBetweenLetters;

    public float cooldownDuration = 1.0f;
    [HideInInspector] public bool canUseSentenceAbility;

    public HUD.CharacterEnum characterEnum;
    public string characterName;

    SpriteRenderer sprite;
    Material initialMaterial;
    public Material greenMaterial;
    public Material whiteMaterial;

    public AudioSource hitSound;

    private void Awake()
    {
        currentArmor = maxArmor;
        canShoot = true;
        canUseSentenceAbility = true;
        sprite = GetComponentInChildren<SpriteRenderer>();
        initialMaterial = sprite.material;
        //thrustParticles = GetComponentInChildren<ParticleSystem>();
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
        //thrustParticles.Emit(1);
        
        foreach(ParticleSystem particleSystem in thrustParticleSystems)
        {
            particleSystem.Emit(1);
        }
    }
    public void FireProjectile()
    {
        GameObject projectile = Instantiate(damageProjectilePrefab, projectileSpawnPoint.position, transform.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(transform.up * projectileSpeed);
        projectile.GetComponent<Projectile>().GetFired(gameObject);
        Destroy(projectile, 4);
        StartCoroutine(FireRateBuffer());
    }

    public void FireRateCoolDown()
    {
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
        hitSound.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
        hitSound.Play();

        currentArmor -= damageToGive;
        if (currentArmor <= 0)
        {
            Explode();
        }

        if (GetComponent<PlayerShip>())
        {
            HUD.Instance.DisplayPlayerHealth(currentArmor, maxArmor);
        }

        StartCoroutine(FlashWhite());

    }
    public void Explode()
    {
        ScreenShakeManager.Instance.ShakeScreen();
        Instantiate(Resources.Load("Explosion"), transform.position, transform.rotation);

        if (GetComponent<PlayerShip>())
        {
            HUD.Instance.Restart();
        }

        if (tag == "Jimothy")
        {
            HUD.Instance.HandleWin();
        }

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
        HUD.Instance.DisplayDialogue(characterEnum, characterName, sentenceToShoot, 1f);
    }

    private IEnumerator ShootSentenceCo(string sentence, bool isGoodGuy)
    {
        string newSentence = sentence;

        if (GetComponentInChildren<DetatchedAim>()) // if we have a turret
        {
            if (GetComponentInChildren<DetatchedAim>().transform.rotation.z < 0)
            {
                char[] stringArray = newSentence.ToCharArray();
                Array.Reverse(stringArray);
                newSentence = new string(stringArray);
            }
        }
        else // if we DONT have a turret
        {
            if (transform.rotation.z < 0)
            {
                char[] stringArray = newSentence.ToCharArray();
                Array.Reverse(stringArray);
                newSentence = new string(stringArray);
            }
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

            projectile.GetComponent<Rigidbody2D>().AddForce(projectileSpawnPoint.transform.up * projectileSpeed);
            projectile.GetComponent<Projectile>().GetFired(gameObject);
            projectile.GetComponent<Projectile>().letter.SetText(character.ToString());
            projectile.transform.eulerAngles = Vector3.zero;
            Destroy(projectile, 4);
            yield return new WaitForSeconds(secondsBetweenLetters);
        }

        canUseSentenceAbility = true;
    }

    public void ShootConvert() //Good Guy 1
    {
        ShootSentence(true);
        canUseSentenceAbility = false;
    }

    public void ShootShield() //Good Guy 2
    {
        GameObject shield = Instantiate(shieldPrefab, transform.position, transform.rotation, null);
        shield.GetComponent<CircleShield>().Init("Not today, Honey :)", true);
        shield.GetComponent<FollowTarget>().target = transform;
        canUseSentenceAbility = false;
        StartCoroutine(StartCooldown());
    }

    public void ShootBackupBuddy() //Good Guy 3
    {

    }

    public void ShootDamage()  // Bad Guy 1
    {
        ShootSentence(false);
        canUseSentenceAbility = false;
    }

    public void ShootSpaceRage() // Bad Guy 2
    {
        GameObject shield = Instantiate(badShieldPrefab, transform.position, transform.rotation, null);
        shield.GetComponent<CircleShield>().Init("Get outta the way fool!", true);
        shield.GetComponent<FollowTarget>().target = transform;

        canUseSentenceAbility = false;
        StartCoroutine(StartCooldown());
    }

    public void ShootCensorBeam() // Bad Guy 3
    {

    }

    public IEnumerator StartCooldown()
    {
        canUseSentenceAbility = false;
        print("Space Rage in CoolDown");
        yield return new WaitForSeconds(cooldownDuration);
        canUseSentenceAbility = true;
    }

    public void FlashGreen()
    {
        StartCoroutine(FlashGreenCo());
    }

    private IEnumerator FlashGreenCo()
    {
        sprite.material = greenMaterial;
        yield return new WaitForSeconds(0.02f);
        sprite.material = initialMaterial;
    }

    private IEnumerator FlashWhite()
    {
        sprite.material = whiteMaterial;
        yield return new WaitForSeconds(0.02f);
        sprite.material = initialMaterial;
    }
}
