using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : Ship
{
    Transform target;
    public bool canFireAtPlayer;
    [HideInInspector] public bool isConverted;

    void Start()
    {
        target = FindObjectOfType<PlayerShip>().transform;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerShip>())
        {
            collision.gameObject.GetComponent<PlayerShip>().TakeDamage(1);
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
        FlyTowardPlayer();

        if (canFireAtPlayer && canShoot)
        {
            ShootDamage();
            FireRateCoolDown();
        }
    }

    void FlyTowardPlayer()
    {
        Vector2 directionToFace = new Vector2(
            target.position.x - transform.position.x, target.position.y - transform.position.y);
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

            foreach (EnemyShip enemyShip in enemyShips)
            {
                if (enemyShip != this)
                {
                    target = enemyShip.transform;
                    break;
                }
            }
        }
    }
}
