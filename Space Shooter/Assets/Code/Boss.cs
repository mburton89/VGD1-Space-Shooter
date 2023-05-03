using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public bool canUseAbility;   
    Transform bossLocation;
    Transform playerLocation;
    float distanceBetweenBossAndPlayer;
    public float abilityDistanceLimit;
    public float abilityCooldownTime;

    public bool isCooldownOver;


    void Update()
    {
        AbilityUsageCheck();
        AbilityAvailableTimer();
    }
   
    public void AbilityUsageCheck()
    {
        playerLocation = FindObjectOfType<PlayerShip>().transform;
        bossLocation = FindObjectOfType<Boss>().transform;
        distanceBetweenBossAndPlayer = Vector3.Distance(playerLocation.position, bossLocation.position);

        if (distanceBetweenBossAndPlayer < abilityDistanceLimit)
        {
           canUseAbility = true;          
        }

        
    }

    public void AbilityAvailableTimer()
    {

        if (canUseAbility && isCooldownOver)
        {

            print("Ability Used");
            StartCoroutine(AbilityCooldown());
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
