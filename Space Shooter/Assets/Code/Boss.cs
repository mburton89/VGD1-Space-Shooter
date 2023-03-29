using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Ship
{
    Transform target;
    public bool canFireAtPlayer;
    public bool canUseAbility;
    Transform bossLocation;
    Transform playerLocation;
    float distanceBetweenBossAndPlayer;
    public float abilityDistanceLimit;

    void Start()
    {
        target = FindObjectOfType<PlayerShip>().transform;
        canUseAbility = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerShip>())
        {
            collision.gameObject.GetComponent<PlayerShip>().TakeDamage(1);
            Explode();
        }
    }
    //Code used to enable the ability usage for bosses
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
}
