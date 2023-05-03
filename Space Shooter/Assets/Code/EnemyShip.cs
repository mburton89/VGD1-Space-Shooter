using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : Ship
{
    [HideInInspector] public Transform target;
    public bool canFireAtPlayer;
    [HideInInspector] public bool isConverted;
    public bool isBoss;

    void Start()
    {

        target = FindObjectOfType<PlayerShip>().transform;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isBoss == false)
        if (collision.gameObject.GetComponent<PlayerShip>())
        {
            collision.gameObject.GetComponent<PlayerShip>().TakeDamage(10);
            Explode();
        }

        if (collision.gameObject.GetComponent<EnemyShip>() && isConverted)
        {
            collision.gameObject.GetComponent<EnemyShip>().Explode();
            Explode();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            FlyTowardPlayer();
        }

        if (canFireAtPlayer && canShoot)
        {
            ShootDamage();
            FireRateCoolDown();
        }
    }

    public void FlyTowardPlayer()
    {
        if (target == null) return;

        Vector2 directionToFace = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
        transform.up = directionToFace;
        Thrust();
    }

    public void TryConvert()
    {
        int rand = Random.Range(0, 10);
        if (rand == 5)
        {
            isConverted = true;
            EnemyShip[] enemyShips = FindObjectsOfType<EnemyShip>();

            if (enemyShips.Length > 1)
            {
                foreach (EnemyShip enemyShip in enemyShips)
                {
                    if (enemyShip != this)
                    {
                        target = enemyShip.transform;
                        break;
                    }
                }
            }
            else
            {
                TakeDamage(8);
            }
        }
    }
}
