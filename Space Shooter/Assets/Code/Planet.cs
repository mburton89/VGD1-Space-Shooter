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

    private void Start()
    {
        currentArmor = maxArmor;
    }

    public void SpawnEnemyShip()
    { 
        int rand = Random.Range(0, enemyShipPrefabs.Count);
        Instantiate(enemyShipPrefabs[rand], spawnPoint.position, transform.rotation, null);
    }

    public void TakeDamage(int damageToGive)
    {
        //TODO: play getHitSound
        int remainder = currentArmor % 20; 
        if (remainder == 0)
        {
            SpawnEnemyShip();
        }

        currentArmor -= damageToGive;
        if (currentArmor <= 0)
        {
            Explode();
        }

        HUD.Instance.DisplayPlayerHealth(currentArmor, maxArmor);

        if (GetComponent<FlashWhite>())
        {
            GetComponent<FlashWhite>().Flash();
        }
    }

    public void Explode()
    {
        ScreenShakeManager.Instance.ShakeScreen();
        Instantiate(Resources.Load("Explosion"), transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
