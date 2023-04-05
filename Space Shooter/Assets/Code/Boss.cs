using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : EnemyShip
{
    
    public bool canUseAbility = false;   
    Transform bossLocation;
    Transform playerLocation;
    float distanceBetweenBossAndPlayer;
    public float abilityDistanceLimit;
    public float abilityCooldownTime;

    [HideInInspector] public bool isCooldownOver;

    void Update()
    {
        FlyTowardPlayer();
        AbilityUsageCheck();
        UseAbility();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerShip>())
        {
            collision.gameObject.GetComponent<PlayerShip>().TakeDamage(1);
            Explode();
        }
    }
   
    public void AbilityUsageCheck()
    {
        playerLocation = FindObjectOfType<PlayerShip>().transform;
        bossLocation = FindObjectOfType<Boss>().transform;
        distanceBetweenBossAndPlayer = Vector3.Distance(playerLocation.position, bossLocation.position);

        if (distanceBetweenBossAndPlayer < abilityDistanceLimit && isCooldownOver == true)
        {
           canUseAbility = true;          
        }

        StartCoroutine(AbilityCooldown());
    }

    public void UseAbility()
    {
        
        if (canUseAbility == true)
        {
        
            print("Ability Used");
            canUseAbility = false;
            
        }

    }

    private IEnumerator AbilityCooldown()
    {
        isCooldownOver = false;
        yield return new WaitForSeconds(abilityCooldownTime);
        isCooldownOver = true;
    }

}
