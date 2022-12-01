using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public List<EnemyShip> enemyShipPrefabs;
    public Transform spawnPoint;

    public int maxArmor;
    [HideInInspector] int currentArmor;

    [HideInInspector] bool isInCombat;

    public Color healthColor;

    int timesHit;

    private void Start()
    {
        currentArmor = maxArmor;
    }

    public void SpawnEnemyShip()
    {
        if (enemyShipPrefabs == null) return;

        int rand = Random.Range(0, enemyShipPrefabs.Count);
        Instantiate(enemyShipPrefabs[rand], spawnPoint.position, transform.rotation, null);
    }

    public void TakeDamage(int damageToGive)
    {
        if (!isInCombat)
        {
            SmartSoundManager.Instance.ToggleMusic();
        }

        //TODO: play getHitSound
        timesHit++;
        if (timesHit == 8)
        {
            SpawnEnemyShip();
            timesHit = 0;
        }

        currentArmor -= damageToGive;
        if (currentArmor <= 0)
        {
            Explode();
        }

        HUD.Instance.DisplayPlanetHealth(currentArmor, maxArmor, healthColor);

        if (GetComponent<FlashWhite>())
        {
            GetComponent<FlashWhite>().Flash();
        }

        SmartSoundManager.Instance.PlayShipHitSound();
    }

    public void Explode()
    {
        HUD.Instance.HidePlanetHealth();
        ScreenShakeManager.Instance.ShakeScreen();
        Instantiate(Resources.Load("Explosion"), transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
